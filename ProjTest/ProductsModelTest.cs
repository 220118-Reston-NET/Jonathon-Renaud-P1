using ProjModel;
using Xunit;

namespace ProjTest;

public class ProductsModelTest
{
    [Fact]
    public void ProductsNameShouldSetValidData()
    {
            Products prod = new Products();
            string validProductsName = "Generic Product";

            //Act
            prod.Name = validProductsName;

            //Assert
            Assert.NotNull(prod.Name); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validProductsName, prod.Name); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void PriceShouldSetValidData()
    {
            Products prod = new Products();
            double validPrice = 19.99;

            //Act
            prod.Price = validPrice;

            //Assert
            Assert.NotNull(prod.Price); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validPrice, prod.Price); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void DescriptionShouldSetValidData()
    {
            Products prod = new Products();
            string validDescription = "Generic Description";

            //Act
            prod.Description = validDescription;

            //Assert
            Assert.NotNull(prod.Description); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validDescription, prod.Description); //checks if the property does indeed hold the same value as what we set it as
        }

}