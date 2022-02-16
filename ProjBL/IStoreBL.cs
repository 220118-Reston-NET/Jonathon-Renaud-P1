using ProjModel;

namespace ProjBL
{

    public interface IStoreBL
    {

        List<StoreFront> ViewStoreInventory(string p_address);

        List<Products> GetProductsByStore(string p_address);
        void UpdateInventory(int p_productID, int p_quantity, int storeID);    

        public Orders InitializeOrder(Orders p_order);

        LineItems MakeOrder(LineItems p_lineItems, int orderID, int storeID);

        List<Orders> GetOrdersByCustomerEmail(string p_searchCriteria);

        List<Products> ViewCurrentOrder(int p_productID, string storeAddress);

        List<StoreFront> SearchStoreByAddress(string p_address);
        List<Orders> GetOrdersByStoreAddress(string p_searchCriteria);
        List<Products> GetProductsInOrder(int p_orderID);
        bool StoreQuantityIsLessThanOrdered(int p_id, int p_quantity, int p_storeID);
        List<StoreFront> GetAllStores();


        

    }

}