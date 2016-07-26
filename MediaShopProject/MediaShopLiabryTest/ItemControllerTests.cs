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
    public class ItemControllerTests
    {
        [TestMethod]
        public void Test_GetAllBooks_Return3Books_WhenThereAre3InDatabase()
        {
            //arrange
            int expected = 3;
            var pretenddata = new List<Books>{
                new Books { id =1},
                new Books { id =2},
                new Books { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            //act

            var actual = classUnderTest.GetAllBooks().Count;

            //assert
            Assert.AreEqual(expected, actual);            
        }

        [TestMethod]
        public void Test_GetAllDVDS_Return3DVD_WhenThereAre3InDatabase()
        {
            //arrange
            int expected = 3;
            var pretenddata = new List<DVD>{
                new DVD { id =1},
                new DVD { id =2},
                new DVD { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            //act

            var actual = classUnderTest.GetAllDVDs().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddBook_ABookIsAddedToTheList_BothAddAndSaveAreCalled()
        {
            //arrange
            var mockDbSet = new Mock<IDbSet<Books>>();
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            Books booktest = new Books() { id = 1, author = "bl", title = "blbl", quantity = 2, price =2.2m };

            //act
            classUnderTest.AddBook(booktest);
            
            //arrange

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Add(It.IsAny<Books>()),Times.Once);  
        }

       

        [TestMethod]
        public void Test_AddDvd_ADvdIsAddedToTheList_BothAddAndSaveAreCalled()
        {
            //arrange
            var mockDbSet = new Mock<IDbSet<DVD>>();
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            DVD dvdtest = new DVD() { id = 1, director= "bd", price = 22.2m, quantity= 2, title ="bf"};

            //act
            classUnderTest.AddDvd(dvdtest);

            //arrange

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Add(It.IsAny<DVD>()), Times.Once);
        }



        [TestMethod]
        public void Test_RemoveBook_BookIsRemoved_BothremoveAndSaveAreCalled()
        {
            //arrange
            var pretenddata = new List<Books>{
                new Books { id =1},
                new Books { id =2},
                new Books { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);


            //act
            classUnderTest.RemoveBook(1);


            //arrange

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Remove(It.IsAny<Books>()), Times.Once);
        }



        [TestMethod]
        public void Test_RemoveDvd_DvdIsRemoved_BothremoveAndSaveAreCalled()
        {
            //arrange
            var pretenddata = new List<DVD>{
                new DVD { id =1},
                new DVD { id =2},
                new DVD { id =3}

            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();
            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            //act
            classUnderTest.RemoveDvds(1);
            

            //arrange

            mockContent.Verify(d => d.SaveChanges(), Times.Once);
            mockDbSet.Verify(s => s.Remove(It.IsAny<DVD>()), Times.Once);
        }



        [TestMethod]
        public void Test_UppdateDvd_DvdIsUppdated_SaveIsCalledAndUpdateOccurs()
        {
            //arrange
            var pretenddata = new List<DVD>{
                new DVD { id =1}
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();
            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());
            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            DVD updatedvd = new DVD() {title = "test", price = 22m, director = "whocares", quantity = 0 };

            //act
            classUnderTest.UpdateDvds(1, updatedvd);
            var datadvd = mockContent.Object.dvd.Where(x => x.id == 1).First();
            var expected = "test";

            //assert
            Assert.AreEqual(expected, datadvd.title);
            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_UppdateBook_BookIsUppdated_SaveIsCalledAndUpdateOccurs()
        {
            //arrange
            var pretenddata = new List<Books>{
                new Books { id =1},
               
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Books>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.books = mockDbSet.Object;

            var classUnderTest = new ItemController(mockContent.Object);

            Books updatebooks = new Books() { title = "test"};

            //act
            classUnderTest.UpdateBook(1, updatebooks);
            var databook = mockContent.Object.books.Where(x => x.id == 1).First();
            var expected = "test";

            //assert
            Assert.AreEqual(expected, databook.title);
            mockContent.Verify(d => d.SaveChanges(), Times.Once);
        }
    }
}
