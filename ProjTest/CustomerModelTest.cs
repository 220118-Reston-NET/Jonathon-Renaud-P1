using ProjModel;
using Xunit;

namespace ProjTest;

public class CustomerModelTest
{
    [Fact]
    public void NameShouldSetValidData()
    {
            Customer cust = new Customer();
            string validName = "Jonathon Renaud";

            //Act
            cust.Name = validName;

            //Assert
            Assert.NotNull(cust.Name); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validName, cust.Name); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void AddressShouldSetValidData()
    {
            Customer cust = new Customer();
            string validAddress = "123 Main Street";

            //Act
            cust.Address = validAddress;

            //Assert
            Assert.NotNull(cust.Address); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validAddress, cust.Address); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void EmailShouldSetValidData()
    {
            Customer cust = new Customer();
            string validEmail = "jon@jon.com";

            //Act
            cust.Email = validEmail;

            //Assert
            Assert.NotNull(cust.Email); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validEmail, cust.Email); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void PhoneNumberShouldSetValidData()
    {
            Customer cust = new Customer();
            string validPhoneNumber = "1111115555";

            //Act
            cust.PhoneNumber = validPhoneNumber;

            //Assert
            Assert.NotNull(cust.PhoneNumber); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validPhoneNumber, cust.PhoneNumber); //checks if the property does indeed hold the same value as what we set it as
        }        
}