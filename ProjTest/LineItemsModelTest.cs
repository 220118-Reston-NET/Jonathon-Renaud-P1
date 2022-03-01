using ProjModel;
using Xunit;

namespace ProjTest;

public class LineItemsModelTest
{
    
    [Fact]
    public void QuantityShouldSetValidData()
    {
            LineItems lineItems = new LineItems();
            int validQuantity = 12;

            //Act
            lineItems.ProductQuantity = validQuantity;

            //Assert
            Assert.Equal(validQuantity, lineItems.ProductQuantity); //checks if the property does indeed hold the same value as what we set it as
        }

        [Fact]
    public void ProductIDShouldSetValidData()
    {
            LineItems lineItems = new LineItems();
            int validProductID = 12;

            //Act
            lineItems.ProductID = validProductID;

            //Assert
            Assert.Equal(validProductID, lineItems.ProductID); //checks if the property does indeed hold the same value as what we set it as
        }

    

}