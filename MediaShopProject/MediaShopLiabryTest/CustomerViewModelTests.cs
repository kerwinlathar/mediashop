using MediaShopLibary;
using MediaShopWpfUi.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLiabryTest
{
    [TestClass]
    public class CustomerViewModelTests
    {


        [TestMethod]
        public void Test_AddCustomerMethod_AddMethodIsCalled()
        {
            //arrange
            var pretenddata = new List<Customer>{
                new Customer { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;
            var mockitemcontrol = new Mock<CustomerController>(mockContent.Object);
            var classUnderTest = new CustomerViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            classUnderTest.name = "test";
            classUnderTest.password = "test";

            //act
            classUnderTest.Add();

            //assert
            mockDbSet.Verify(s => s.Add(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveCustomerMethod_RemoveMethodIsCalled()
        {
            var pretenddata = new List<Customer>{
                new Customer { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;
            var mockitemcontrol = new Mock<CustomerController>(mockContent.Object);
            var classUnderTest = new CustomerViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            
            //act
            classUnderTest.Remove();

            //arrange
            mockDbSet.Verify(s => s.Remove(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void Test_UpdateDvDMethod_RemoveMethodIsCalled()
        {
            var pretenddata = new List<Customer>{
                new Customer { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Customer>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.customers = mockDbSet.Object;
            var mockitemcontrol = new Mock<CustomerController>(mockContent.Object);
            var classUnderTest = new CustomerViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            classUnderTest.name = "test";
            var expected = "test";

            //act
            classUnderTest.Update();
            var datadvd = mockContent.Object.customers.Where(x => x.id == 1).First();

            //assert
            Assert.AreEqual(expected, datadvd.name);
        }
    }
}
