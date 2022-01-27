using ProjModel;
using Xunit;

namespace ProjTest;

public class LineItemsModelTest
{
    [Fact]
    public void ProductShouldSetValidData()
    {
            LineItems lineItems = new LineItems();
            string validProduct = "Generic Dress";

            //Act
            lineItems.Product = validProduct;

            //Assert
            Assert.NotNull(lineItems.Product); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validProduct, lineItems.Product); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void QuantityShouldSetValidData()
    {
            LineItems lineItems = new LineItems();
            int validQuantity = 12;

            //Act
            lineItems.Quantity = validQuantity;

            //Assert
            Assert.NotNull(lineItems.Quantity); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validQuantity, lineItems.Quantity); //checks if the property does indeed hold the same value as what we set it as
        }

}