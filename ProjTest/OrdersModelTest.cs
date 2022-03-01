using ProjModel;
using Xunit;

namespace ProjTest;

public class OrdersModelTest
{
    [Fact]
    public void StoreFrontShouldSetValidData()
    {
            //Arrange - creates any objects we need for the test
            Orders orders = new Orders();
            string validStoreFront = "Test Location";

            //Act - acting as if we set the value
            orders.StoreFront = validStoreFront;

            //Assert
            Assert.NotNull(orders.StoreFront); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validStoreFront, orders.StoreFront); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void TotalPriceShouldSetValidData()
    {
            Orders orders = new Orders();
            double validTotalPrice = 19.99;

            //Act
            orders.TotalPrice = validTotalPrice;

            //Assert
            Assert.NotNull(orders.TotalPrice); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validTotalPrice, orders.TotalPrice); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void StoreIDShouldSetValidData()
    {
            Orders orders = new Orders();
            int validStoreID = 212;

            //Act
            orders.StoreID = validStoreID;

            //Assert
            Assert.NotNull(orders.StoreID); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validStoreID, orders.StoreID); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    
    public void OrderIDShouldSetValidData()
    {
            Orders orders = new Orders();
            int validOrderID = 212;

            //Act
            orders.OrderID = validOrderID;

            //Assert
            Assert.NotNull(orders.OrderID); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validOrderID, orders.OrderID); //checks if the property does indeed hold the same value as what we set it as
        }  
             
[Fact]
    
    public void CustomerIDShouldSetValidData()
    {
            Orders orders = new Orders();
            int validCustomerID = 212;

            //Act
            orders.CustomerID = validCustomerID;

            //Assert
            Assert.NotNull(orders.CustomerID); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validCustomerID, orders.CustomerID); //checks if the property does indeed hold the same value as what we set it as
        }  
}