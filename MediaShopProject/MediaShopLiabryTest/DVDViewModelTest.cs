using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using MediaShopLibary;
using Moq;
using System.Data.Entity;
using MediaShopWpfUi.ViewModel;

namespace MediaShopLiabryTest
{
    [TestClass]
    public class DVDViewModelTest
    {
        [TestMethod]
        public void Test_AddDvDMethod_AddMethodIsCalled()
        {
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
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new DvdViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            classUnderTest.title = "test";
            classUnderTest.price = 0m;
            classUnderTest.director = "test";

            //act
            classUnderTest.Add();

            //arrange
            mockitemcontrol.Verify(x => x.AddDvd(It.IsAny<DVD>()), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveDvDMethod_RemoveMethodIsCalled()
        {
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
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new DvdViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;

            //act
            classUnderTest.Remove();

            //arrange
            mockDbSet.Verify(s => s.Remove(It.IsAny<DVD>()), Times.Once);
        }

        [TestMethod]
        public void Test_UpdateDvDMethod_RemoveMethodIsCalled()
        {
            //arrange
            var pretenddata = new List<DVD>{
                new DVD { id =1},
                
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<DVD>>();

            mockDbSet.Setup(d => d.Provider).Returns(pretenddata.Provider);
            mockDbSet.Setup(d => d.Expression).Returns(pretenddata.Expression);
            mockDbSet.Setup(d => d.ElementType).Returns(pretenddata.ElementType);
            mockDbSet.Setup(d => d.GetEnumerator()).Returns(pretenddata.GetEnumerator());

            var mockContent = new Mock<ModelMediaShopData>();
            mockContent.SetupAllProperties();
            mockContent.Object.dvd = mockDbSet.Object;
            var mockitemcontrol = new Mock<ItemController>(mockContent.Object);
            var classUnderTest = new DvdViewModel(mockitemcontrol.Object);
            classUnderTest.id = 1;
            classUnderTest.title = "test";
            var expected = "test";

            //act
            classUnderTest.Update();
            var datadvd = mockContent.Object.dvd.Where(x => x.id == 1).First();

            //assert
            Assert.AreEqual(expected, datadvd.title);
        }
    }
}
