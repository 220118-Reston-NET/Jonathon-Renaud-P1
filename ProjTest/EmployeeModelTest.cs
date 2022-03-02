using ProjModel;
using Xunit;

namespace ProjTest;

public class EmployeeModelTest
{
    [Fact]
    public void NameShouldSetValidData()
    {
            //Arrange - creates any objects we need for the test
            Employee emp = new Employee();
            string validName = "Jonathon Renaud";

            //Act - acting as if we set the value
            emp.Name = validName;

            //Assert
            Assert.NotNull(emp.Name); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validName, emp.Name); //checks if the property does indeed hold the same value as what we set it as
        }
    
    [Fact]
    public void IsAdminShouldSetValidData()
    {
            Employee emp = new Employee();
            bool validStatus = true;

            //Act
            emp.IsAdmin = validStatus;

            //Assert
            Assert.Equal(validStatus, emp.IsAdmin); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void EmailShouldSetValidData()
    {
            Employee emp = new Employee();
            string validEmail = "jon@jon.com";

            //Act
            emp.Email = validEmail;

            //Assert
            Assert.NotNull(emp.Email); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validEmail, emp.Email); //checks if the property does indeed hold the same value as what we set it as
        }

    [Fact]
    public void PasswordShouldSetValidData()
    {
            Employee emp = new Employee();
            string validPassword = "test";

            //Act
            emp.Password = validPassword;

            //Assert
            Assert.NotNull(emp.Password); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validPassword, emp.Password); //checks if the property does indeed hold the same value as what we set it as
        }        
    [Fact]
    public void EmpIDShouldSetValidData()
    {
            Employee emp = new Employee();
            int validempID = 55;

            //Act
            emp.EmployeeID = validempID;

            //Assert
            Assert.Equal(validempID, emp.EmployeeID); //checks if the property does indeed hold the same value as what we set it as
        }  
}