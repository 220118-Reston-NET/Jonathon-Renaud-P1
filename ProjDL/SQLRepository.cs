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

            // Server=tcp:projectstoredb.database.windows.net,1433;Initial Catalog=StoreDB;Persist Security Info=False;User ID=storeAdmin;Password=ZxCv1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
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
    }

}