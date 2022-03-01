using ProjModel;
using Xunit;

namespace ProjTest;

public class ProductsModelTest
{

    [Fact]
    
    public void ProdIDShouldSetValidData()
    {
            Products Product = new Products();
            int validProdID = 212;

            //Act
            Product.ProdID = validProdID;

            //Assert
            Assert.NotNull(Product.ProdID); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validProdID, Product.ProdID); //checks if the property does indeed hold the same value as what we set it as
        }  

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

    [Fact]
    
    public void QuantityShouldSetValidData()
    {
            Products Product = new Products();
            int validQuantity = 212;

            //Act
            Product.Quantity = validQuantity;

            //Assert
            Assert.NotNull(Product.Quantity); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validQuantity, Product.Quantity); //checks if the property does indeed hold the same value as what we set it as
        }  

    [Fact]
    public void StoreFrontShouldSetValidData()
    {
            Products prod = new Products();
            string validStoreFront = "Generic StoreFront";

            //Act
            prod.StoreFront = validStoreFront;

            //Assert
            Assert.NotNull(prod.StoreFront); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validStoreFront, prod.StoreFront); //checks if the property does indeed hold the same value as what we set it as
        }

}