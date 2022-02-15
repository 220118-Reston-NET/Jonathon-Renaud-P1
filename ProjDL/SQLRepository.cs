using System.Data.SqlClient;
using ProjModel;

namespace ProjDL 
{

    public class SQLRepository : IRepository
    {
        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            string sqlQuery = @"insert into Customer
                                 values (@custName, @custAddress, @custPhoneNumber, @custEmail)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))

            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.AddWithValue("custName", p_customer.Name);
                command.Parameters.AddWithValue("custAddress", p_customer.Address);
                command.Parameters.AddWithValue("custPhoneNumber", p_customer.PhoneNumber);
                command.Parameters.AddWithValue("custEmail", p_customer.Email);

                command.ExecuteNonQuery();
            }

            return p_customer;

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCustomer = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        CustID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Email = reader.GetString(4)
                        
                    });
                }


            }
            return listOfCustomer;
        }

        public List<StoreFront> GetStoreFronts()
        {
            
            List<StoreFront> listOfStores = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfStores.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    });

                }

            }

            return listOfStores;

        }

        public Orders InitializeOrder(Orders p_order)
        {
            
            string sqlQuery = @"insert into Orders
                                values(@orderTotalCost, @custID)";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custID", p_order.CustomerID);
                // command.Parameters.AddWithValue("@storeID", p_order.StoreID);
                command.Parameters.AddWithValue("@orderTotalCost", p_order.TotalPrice);

                command.ExecuteNonQuery();

            }

            sqlQuery = @"select max(o.ordersID) from Orders o";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    p_order.OrderID = reader.GetInt32(0);
                }

            }

            return p_order;

        }

       

        

        public LineItems MakeOrder(LineItems p_lineItems, int p_orderID, int p_storeID)
        {         
            string sqlQuery = @"select sfp.quantity from storeFront_product sfp
                            where sfp.prodID = @prodID
                            and sfp.storeID = @storeID
                            ";

            List<StoreFront> listOfStores = new List<StoreFront>();

            int temporaryQuantity = 0;
            // int p_storeID = listOfStores[0].StoreID;

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", p_lineItems.ProductID);
                command.Parameters.AddWithValue("@storeID", p_storeID);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    temporaryQuantity = reader.GetInt32(0);
                }

                temporaryQuantity = temporaryQuantity - p_lineItems.ProductQuantity;
                if(temporaryQuantity >= 0)
                {
                    int subtractFromTotalInventory = 0 - p_lineItems.ProductQuantity;
                    UpdateInventory(p_lineItems.ProductID, subtractFromTotalInventory, p_storeID);
                }
                else
                {
                    Exception exc = new Exception("There are not enough to make the purchase!");
                     return p_lineItems;
                }

            }

        sqlQuery = @"insert into LineItems
                        values(@ordersID, @productID, @quantity)";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ordersID", p_orderID);
                command.Parameters.AddWithValue("@productID", p_lineItems.ProductID);
                command.Parameters.AddWithValue("@quantity", p_lineItems.ProductQuantity);

                command.ExecuteNonQuery();

            }

            
            try
            {
                sqlQuery = @"insert into storeFront_orders
                        values(@storeID, @ordersID)";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", p_storeID);
                command.Parameters.AddWithValue("@ordersID", p_orderID);
                command.ExecuteNonQuery();

            }
                
            }
            catch (System.Exception)
            {
                
               
            }
            
        

            return p_lineItems;

        }
                public List<Orders> GetAllOrders()
        {
            List<Orders> listOfOrders = new List<Orders>();

            string sqlQuery = @"select * from Orders";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfOrders.Add(new Orders()
                    {

                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetDouble(1),
                        CustomerID = reader.GetInt32(2)

                    });

                }

            }

            return listOfOrders;
        }
        

        public void UpdateInventory(int p_productID, int p_quantity, int p_storeID)
        {
            
            List<StoreFront> listOfStores = new List<StoreFront>();
            int temporaryQuantity = 0;
            string sqlQuery = @"select sfp.quantity from storeFront_product sfp
                            where sfp.prodID = @prodID
                            and sfp.storeID = @storeID
                            ";
            
            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", p_productID);
                command.Parameters.AddWithValue("@storeID", p_storeID);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    temporaryQuantity = reader.GetInt32(0);
                }

                temporaryQuantity = temporaryQuantity + p_quantity;
            
            }
            
            sqlQuery = @"update storeFront_product
                        set quantity = @quantity
                        where prodID = @prodID
                        and storeID = @storeID";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command= new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@quantity", temporaryQuantity);
                command.Parameters.AddWithValue("@prodID", p_productID);
                command.Parameters.AddWithValue("@storeID", p_storeID);

                command.ExecuteNonQuery();
            }

        }

       
        

        List<Products> IRepository.GetProductsByStore(string p_address)
        {
            List<Products> listOfProducts = new List<Products>();

            string sqlQuery = @"select p.prodID, p.prodName, p.prodPrice, p.prodDesc, sp.quantity from Product p
                            inner join storeFront_product sp on sp.prodID = p.prodID 
                            inner join StoreFront s on s.storeID = sp.storeID
                            where s.storeAddress = @storeAddress";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeAddress", p_address);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    listOfProducts.Add(new Products()
                    {
                        ProdID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDouble(2),
                        Description = reader.GetString(3),
                        Quantity = reader.GetInt32(4)
                    });

                }

            }

            return listOfProducts;
        }

            public List<Orders> GetAllOrdersByCustomer(int p_custID)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string sqlQuery = @"select * from Orders o 
                                inner join storeFront_orders sfo on o.ordersID = sfo.ordersID
                                where o.custID = @custID;";
                                // inner join LineItems li on o.ordersID = li.ordersID
                                // inner join Product p on li.productID = p.prodID

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custID", p_custID);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfOrders.Add(new Orders()
                    {

                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetDouble(1),
                        CustomerID = reader.GetInt32(2),
                        StoreID = reader.GetInt32(3)

                    });

                }

            }

            return listOfOrders;
        }

        public List<Orders> GetAllOrdersByStoreAddress(int storeID)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string sqlQuery = @"select * from Orders o 
                                inner join storeFront_orders sfo on o.ordersID = sfo.ordersID
                                where sfo.storeID = @storeID;";
                                // inner join LineItems li on o.ordersID = li.ordersID
                                // inner join Product p on li.productID = p.prodID

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", storeID);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfOrders.Add(new Orders()
                    {

                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetDouble(1),
                        CustomerID = reader.GetInt32(2),
                        StoreID = reader.GetInt32(3)
                         

                    });

                    

                }

            }

            return listOfOrders;
        }

        public List<Products> GetLineItemDetails(int orderID)
        {
            List<Products> listOfProducts = new List<Products>();

            string sqlQuery = @"select p.prodName, li.quantity, p.prodPrice, p.prodID from LineItems li 
                                inner join Product p on p.prodID = li.productID
                                inner join Orders o on o.ordersID = li.ordersID 
                                inner join storeFront_orders sfo on sfo.ordersID = o.ordersID  
                                WHERE li.ordersID = @ordersID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ordersID", orderID);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfProducts.Add(new Products()
                    {

                        Name = reader.GetString(0),
                        Quantity = reader.GetInt32(1),
                        Price = reader.GetDouble(2),
                        ProdID = reader.GetInt32(3)
                         

                    });

                    

                }

            }

            return listOfProducts;
        }

        public Boolean StoreQuantityIsLessThanOrdered(int choiceID, int itemOrdered, int storeID)
        {

            string sqlQuery = @"select sfp.quantity from storeFront_product sfp
                            where sfp.prodID = @prodID
                            and sfp.storeID = @storeID";

            int tempQuantity = 0;
            
            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", choiceID);
                command.Parameters.AddWithValue("@storeID", storeID);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tempQuantity = reader.GetInt32(0);
                }

                tempQuantity = tempQuantity - itemOrdered;
                if(tempQuantity < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            
            
        }
    }

}