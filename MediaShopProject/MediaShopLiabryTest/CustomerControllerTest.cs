using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MediaShopLibary;
using System.Linq;
using Moq;
using System.Data.Entity;

namespace MediaShopLiabryTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Test_GetAllCustomer_Return3Customers_WhenThereAre3InDatabase()
        {
            //arrange
            int expected = 3;
            var pretenddata = new List<Customer>{
                new Customer { id =1},
                new Customer { id =2},
                new Customer { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;

            var classUnderTest = new CustomerController(mockContent.Object);

            //act

            var actual = classUnderTest.GetAllCustomers().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddCustomer_ACustomerIsAddedToTheList_BothAddAndSaveAreCalled()
        {
            //arrange
            var mockDbSet = new Mock<IDbSet<Customer>>();
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;

            var classUnderTest = new CustomerController(mockContent.Object);

            Customer customertest = new Customer() { id = 1, name ="test"};

            //act
            classUnderTest.AddCustomer(customertest);

            //arrange

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Add(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveCustomer_CustomerIsRemoved_BothremoveAndSaveAreCalled()
        {
            //arrange
            var pretenddata = new List<Customer>{
                new Customer { id =1},
                new Customer { id =2},
                new Customer { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;

            var classUnderTest = new CustomerController(mockContent.Object);


            //act
            classUnderTest.RemoveCustomer(1);


            //assert

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Remove(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void Test_UppdateCustomer_CustomerIsUppdated_SaveIsCalledAndUpdateOccurs()
        {
            //arrange
            var pretenddata = new List<Customer>{
                new Customer { id =1},
                new Customer { id =2},
                new Customer { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;

            var classUnderTest = new CustomerController(mockContent.Object);

            Customer customerupdate = new Customer() { name = "test" };

            //act
            classUnderTest.UpdateCustomer(1, customerupdate);
            var datacust = mockContent.Object.customers.Where(x => x.id == 1).First();
            var expected = "test";

            //assert
            Assert.AreEqual(expected, datacust.name);
            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

    }
}
