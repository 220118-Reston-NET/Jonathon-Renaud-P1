using System.Collections.Generic;
using Moq;
using Xunit;
using ProjModel;
using ProjBL;
using ProjDL;

namespace ProjTest
{
    
    public class StoreBLTest
    {
        [Fact]
        public void ShouldGetAllStores()
        {

            string testName = "Test Test";
            string testAddress = "4567 Test street, Panama City, FL 32401";
            

            StoreFront storeFront = new StoreFront()
            {
                Name = testName,
                Address = testAddress
            };

            List<StoreFront> expectedListOfStoreFronts = new List<StoreFront>();
            expectedListOfStoreFronts.Add(storeFront);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetStoreFronts()).Returns(expectedListOfStoreFronts);            

            IStoreBL StoreBL = new StoreBL(mockRepo.Object);

            List<StoreFront> actualListOfStoreFronts = StoreBL.GetAllStores();

            Assert.Same(expectedListOfStoreFronts, actualListOfStoreFronts);
            Assert.Equal(testName, actualListOfStoreFronts[0].Name);
            Assert.Equal(testAddress, actualListOfStoreFronts[0].Address);
            

        }

        [Fact]
        public void ShouldSearchStoreByAddress()
        {

            string testName = "Test Test";
            string testAddress = "4567 Test street, Panama City, FL 32401";
            string testName2 = "Not Correct";
            string testAddress2 = "999 Null Street, Null, Null, 32401";
            

            StoreFront storeFront = new StoreFront()
            {
                Name = testName,
                Address = testAddress
            };

            StoreFront storeFront2 = new StoreFront()
            {
                Name = testName2,
                Address = testAddress2
            };

            List<StoreFront> expectedListOfStoreFronts = new List<StoreFront>();
            expectedListOfStoreFronts.Add(storeFront);
            expectedListOfStoreFronts.Add(storeFront2);


            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetStoreFronts()).Returns(expectedListOfStoreFronts);            

            IStoreBL StoreBL = new StoreBL(mockRepo.Object);

            StoreFront expectedStoreFront = storeFront;

            List<StoreFront> actualListOfStoreFronts = StoreBL.SearchStoreByAddress("4567 Test street, Panama City, FL 32401");

            Assert.Same(expectedStoreFront, actualListOfStoreFronts[0]);
            

        }

        [Fact]
        public void ShouldGetProductsByStore()
        {
            int testStoreID = 1;
            string testAddress = "627 Test Street";

            int testProductID = 1;
            string testProductName = "Gloria Wig";

            StoreFront store = new StoreFront()
            {
                StoreID = testStoreID,
                Address = testAddress
            };

            Products product = new Products()
            {
                ProdID = testProductID,
                Name = testProductName
            };

            List<Products> expectedListOfStoreProducts = new List<Products>();
            expectedListOfStoreProducts.Add(product);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetProductsByStore(testAddress)).Returns(expectedListOfStoreProducts);            

            IStoreBL StoreBL = new StoreBL(mockRepo.Object);

            List<Products> actualListOfProducts = StoreBL.GetProductsByStore(testAddress);

            Assert.Same(expectedListOfStoreProducts, actualListOfProducts);

        }

        [Fact]

        public void ShouldReturnIfEmployeeIsAdmin()
        {
            

            string testEmail = "Jon@jon.com";
            string testPassword = "password";
            bool testStatus = true;

           Employee emp = new Employee()
            {
                Email = testEmail,
                Password = testPassword,
                IsAdmin = testStatus
            };

            

            List<Employee> expectedListOfEmployees = new List<Employee>();
            expectedListOfEmployees.Add(emp);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllEmployees()).Returns(expectedListOfEmployees);            

            IStoreBL StoreBL = new StoreBL(mockRepo.Object);

            bool actual = StoreBL.IsAdmin("Jon@jon.com", "password");

            Assert.Equal(emp.IsAdmin, actual);
        }

        
        

    }
}