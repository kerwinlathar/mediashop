using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MediaShopLibary;
using Moq;
using System.Data.Entity;
using MediaShopWpfUi.ViewModel;
using System.Linq;

namespace MediaShopLiabryTest
{
    [TestClass]
    public class BookModelViewTest
    {
        [TestMethod]
        public void Test_AddBookMethod_AddMethodIsCalled()
        {
            //arrange
            var pretenddata = new List<Books>{
                new Books { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new BookViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            classUnderTest.title = "test";
            classUnderTest.price = 0m;
            classUnderTest.author = "test";

            //act
            classUnderTest.Add();

            //assert
            mockDbSet.Verify(s => s.Add(It.IsAny<Books>()), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveBookMethod_RemoveMethodIsCalled()
        {
            var pretenddata = new List<Books>{
                new Books { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new BookViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;

            //act
            classUnderTest.Remove();

            //arrange
            mockDbSet.Verify(s => s.Remove(It.IsAny<Books>()), Times.Once);
        }

        [TestMethod]
        public void Test_UpdateDvDMethod_RemoveMethodIsCalled()
        {
            //arrange
            var pretenddata = new List<Books>{
                new Books { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new BookViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;

            classUnderTest.title = "test";
            var expected = "test";

            //act
            classUnderTest.Update();
            var databook = mockContent.Object.books.Where(x => x.id == 1).First();

            //assert
            Assert.AreEqual(expected, databook.title);
        }
    }
}
