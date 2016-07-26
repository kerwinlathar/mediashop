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
    public class QuantityControlerTests
    {
        [TestMethod]
        public void Test_OrderBooks_WhenCalledADecimalIsReturned()
        {
            //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 5;

            //act
            var actual = classUnderTest.OrderBook(1, 5);

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OrderBooks_WhenCalledSaveIsCalled()
        {
            //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            

            //act
            var actual = classUnderTest.OrderBook(1, 5);

            //assert

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_OrderBooks_WhenCalledQuanityisUppdated()
        {
            //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 6;

            //act
            classUnderTest.OrderBook(1, 5);

            var databook = mockContent.Object.books.Where(x => x.id == 1).First();

            var actual = databook.quantity;

            //assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void Test_OrderDvD_WhenCalledADecimalIsReturned()
        {
            //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 5;

            //act
            var actual = classUnderTest.OrderDvd(1, 5);

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OrderDvd_WhenCalledSaveIsCalled()
        {
            //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);



            //act
            var actual = classUnderTest.OrderDvd(1, 5);

            //assert

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_OrderDvd_WhenCalledQuanityisUppdated()
        {
            //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

           
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
              

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 6;

            //act
            classUnderTest.OrderDvd(1, 5);

            var datadvd = mockContent.Object.dvd.Where(x => x.id == 1).First();

            var actual = datadvd.quantity;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_BuyDvd_WhenCalledQuanityisUppdated()
        {  //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 0;

            //act
            classUnderTest.BuyDvd(1, 1, 1);

            var datadvd = mockContent.Object.dvd.Where(x => x.id == 1).First();

            var actual = datadvd.quantity;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_BuyDvd_WhenCalledSaveIsCalled()
        {  //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyDvd(1, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_BuyDvd_WhenCalledADecimalIsReturned()
        {  //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=5.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 5m;

            //act
            var actual = classUnderTest.BuyDvd(1, 1, 1);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledQuanityisUppdated()
        {  //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 0;

            //act
            classUnderTest.BuyBook(1, 1, 1);

            var databook = mockContent.Object.books.Where(x => x.id == 1).First();

            var actual = databook.quantity;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledSaveIsCalled()
        {  //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyBook(1, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledADecimalIsReturned()
        {  //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=5.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            var expected = 5m;

            //act
            var actual = classUnderTest.BuyBook(1, 1, 1);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledIDSaveIsCalled()
        {    //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            

            //act
            var actual = classUnderTest.OrderBook(7, 5);

            //assert

            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Test_BuyDVD_WhenCalledSaveIsCalled()
        {    //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m , quantity = 1},
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            

            //act
            var actual = classUnderTest.OrderDvd(7, 5);

            //assert

            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledWithANonExsistantIDSaveIsNotCalled()
        {  //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyBook(5, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Test_BuyBook_WhenCalledWithAIdThatHasQuantityZeroSaveIsNotCalled()
        {  //arranage
            var pretenddata = new List<Books>{
                new Books { id =1, price=1.0m, quantity=0 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyBook(1, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Test_BuyDvd_WhenCalledWithAnNonExsistantIDSaveIsNotCalled()
        {  //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m, quantity=1 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyDvd(7, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Test_BuyDvd_WhenCalledWithAnIdWithWuantityOfZeroSaveIsNotCalled()
        {  //arranage
            var pretenddata = new List<DVD>{
                new DVD { id =1, price=1.0m, quantity=0 },
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var pretendorder = new List<Order> {
            new Order { id =1 }}.AsQueryable();
            var mockDbSet2 = new Mock<IDbSet<Order>>();
            mockDbSet2.Setup(d => d.Provider).Returns(pretendorder.Provider);
            mockDbSet2.Setup(d => d.Expression).Returns(pretendorder.Expression);
            mockDbSet2.Setup(d => d.ElementType).Returns(pretendorder.ElementType);
            mockDbSet2.Setup(d => d.GetEnumerator()).Returns(pretendorder.GetEnumerator());



            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            mockContent.Object.order = mockDbSet2.Object;

            var classUnderTest = new QuantityControler(mockContent.Object);

            //act
            classUnderTest.BuyDvd(1, 1, 1);

            //assert
            mockContent.Verify(d => d.SaveChanges(), Times.Never);
        }



    }
}


