using System.Collections.Generic;
using Moq;
using Xunit;
using ProjModel;
using ProjBL;
using ProjDL;


namespace ProjTest
{

    public class CustomerBLTest
    {

        [Fact]
        public void ShouldGetAllCustomers()
        {

            string testName = "Jonathon Test";
            string testAddress = "4567 Main street, Panama City, FL 32401";
            string testEmail = "jontest@email.com";
            string testPhoneNumber = "8501237894";

            Customer customer = new Customer()
            {
                Name = testName,
                Address = testAddress,
                Email = testEmail,
                PhoneNumber = testPhoneNumber
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            expectedListOfCustomers.Add(customer);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomers);            

            ICustomerBL CustomerBL = new CustomerBL(mockRepo.Object);

            List<Customer> actualListOfCustomers = CustomerBL.GetAllCustomers();

            Assert.Same(expectedListOfCustomers, actualListOfCustomers);
            Assert.Equal(testName, actualListOfCustomers[0].Name);
            Assert.Equal(testAddress, actualListOfCustomers[0].Address);
            Assert.Equal(testEmail, actualListOfCustomers[0].Email);
            Assert.Equal(testPhoneNumber, actualListOfCustomers[0].PhoneNumber);

        }

        [Fact]
        public void ShouldSearchCustomerByName()
        {
            string testName = "Jonathon Test";
            string testAddress = "4567 Main street, Panama City, FL 32401";
            string testEmail = "jontest@email.com";
            string testPhoneNumber = "8501237894";

            Customer customer = new Customer()
            {
                Name = testName,
                Address = testAddress,
                Email = testEmail,
                PhoneNumber = testPhoneNumber
            };

            string testName2 = "Test Test";
            string testAddress2 = "999 Null Street, Null, Null 55555";
            string testEmail2 = "testtest@email.com";
            string testPhoneNumber2 = "1111111111";

            Customer customer2 = new Customer()
            {
                Name = testName2,
                Address = testAddress2,
                Email = testEmail2,
                PhoneNumber = testPhoneNumber2
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            expectedListOfCustomers.Add(customer);
            expectedListOfCustomers.Add(customer2);


            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomers);            

            ICustomerBL CustomerBL = new CustomerBL(mockRepo.Object);
            Customer expectedCustomer = customer;


            List<Customer> actualListOfCustomers = CustomerBL.SearchCustomerByName("Jon");

            Assert.Same(expectedCustomer, actualListOfCustomers[0]);
            
        }

         [Fact]
        public void ShouldSearchCustomerByAddress()
        {
            string testName = "Jonathon Test";
            string testAddress = "4567 Main street, Panama City, FL 32401";
            string testEmail = "jontest@email.com";
            string testPhoneNumber = "8501237894";

            Customer customer = new Customer()
            {
                Name = testName,
                Address = testAddress,
                Email = testEmail,
                PhoneNumber = testPhoneNumber
            };

            string testName2 = "Test Test";
            string testAddress2 = "999 Null Street, Null, Null 55555";
            string testEmail2 = "testtest@email.com";
            string testPhoneNumber2 = "1111111111";

            Customer customer2 = new Customer()
            {
                Name = testName2,
                Address = testAddress2,
                Email = testEmail2,
                PhoneNumber = testPhoneNumber2
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            expectedListOfCustomers.Add(customer);
            expectedListOfCustomers.Add(customer2);


            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomers);            

            ICustomerBL CustomerBL = new CustomerBL(mockRepo.Object);
            Customer expectedCustomer = customer;


            List<Customer> actualListOfCustomers = CustomerBL.SearchCustomerByAddress("4567");

            Assert.Same(expectedCustomer, actualListOfCustomers[0]);
            
        }

         [Fact]
        public void ShouldSearchCustomerByEmail()
        {
            string testName = "Jonathon Test";
            string testAddress = "4567 Main street, Panama City, FL 32401";
            string testEmail = "jontest@email.com";
            string testPhoneNumber = "8501237894";

            Customer customer = new Customer()
            {
                Name = testName,
                Address = testAddress,
                Email = testEmail,
                PhoneNumber = testPhoneNumber
            };

            string testName2 = "Test Test";
            string testAddress2 = "999 Null Street, Null, Null 55555";
            string testEmail2 = "testtest@email.com";
            string testPhoneNumber2 = "1111111111";

            Customer customer2 = new Customer()
            {
                Name = testName2,
                Address = testAddress2,
                Email = testEmail2,
                PhoneNumber = testPhoneNumber2
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            expectedListOfCustomers.Add(customer);
            expectedListOfCustomers.Add(customer2);


            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomers);            

            ICustomerBL CustomerBL = new CustomerBL(mockRepo.Object);
            Customer expectedCustomer = customer;


            List<Customer> actualListOfCustomers = CustomerBL.SearchCustomerByEmail("jontest@email.com");

            Assert.Same(expectedCustomer, actualListOfCustomers[0]);
            
        }

         [Fact]
        public void ShouldSearchCustomerByPhoneNumber()
        {
            string testName = "Jonathon Test";
            string testAddress = "4567 Main street, Panama City, FL 32401";
            string testEmail = "jontest@email.com";
            string testPhoneNumber = "8501237894";

            Customer customer = new Customer()
            {
                Name = testName,
                Address = testAddress,
                Email = testEmail,
                PhoneNumber = testPhoneNumber
            };

            string testName2 = "Test Test";
            string testAddress2 = "999 Null Street, Null, Null 55555";
            string testEmail2 = "testtest@email.com";
            string testPhoneNumber2 = "1111111111";

            Customer customer2 = new Customer()
            {
                Name = testName2,
                Address = testAddress2,
                Email = testEmail2,
                PhoneNumber = testPhoneNumber2
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            expectedListOfCustomers.Add(customer);
            expectedListOfCustomers.Add(customer2);


            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomers);            

            ICustomerBL CustomerBL = new CustomerBL(mockRepo.Object);
            Customer expectedCustomer = customer;


            List<Customer> actualListOfCustomers = CustomerBL.SearchCustomerByPhoneNumber("8501237894");

            Assert.Same(expectedCustomer, actualListOfCustomers[0]);
            
        }


    }

}