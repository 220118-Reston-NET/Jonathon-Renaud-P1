using ProjModel;
using Xunit;

namespace ProjTest;

public class StoreFrontModelTest
{
    [Fact]
    public void NameShouldSetValidData()
    {
            StoreFront storeFront = new StoreFront();
            string validName = "Le Magasin De Renaud - Downtown";

            //Act
            storeFront.Name = validName;

            //Assert
            Assert.NotNull(storeFront.Name); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validName, storeFront.Name); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void AddressShouldSetValidData()
    {
            StoreFront storeFront = new StoreFront();
            string validAddress = "231 Main Street";

            //Act
            storeFront.Address = validAddress;

            //Assert
            Assert.NotNull(storeFront.Address); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validAddress, storeFront.Address); //checks if the property does indeed hold the same value as what we set it as
        }
  
}