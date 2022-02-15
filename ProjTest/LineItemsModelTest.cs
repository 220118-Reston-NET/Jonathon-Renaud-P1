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
            Assert.NotNull(lineItems.ProductQuantity); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validQuantity, lineItems.ProductQuantity); //checks if the property does indeed hold the same value as what we set it as
        }

}