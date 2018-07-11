using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using FF.Data.Models;
using FF.Contracts.Service;
using FF.Data;

namespace FF.UnitTests.OldTests
{
    [TestClass]
    [Ignore]
    public class FruitFinderDalTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var dal = new FruitFinderDal(new FruitFinderContext(), 
                Mock.Create<IDateTimeService>(), 
                Mock.Create<ISecurityService>());
            Assert.IsNotNull(dal);
        }

        [TestMethod]
        public void SaveReviewTest()
        {
            var fruitReview = new Review();
            var dal = new FruitFinderDal(new FruitFinderContext(),
                Mock.Create<IDateTimeService>(),
                Mock.Create<ISecurityService>());
            dal.SaveReview(fruitReview);
            Assert.AreNotEqual(0, fruitReview.ReviewId);
        }

        [TestMethod]
        public void SaveToDatabaseTest()
        {
            var fruitReview = new Review();
            var mockContext = Mock.Create<FruitFinderContext>();
            Mock.Arrange(() => mockContext.SaveChanges()).OccursOnce();
            var dal = new FruitFinderDal(mockContext,
                Mock.Create<IDateTimeService>(),
                Mock.Create<ISecurityService>());
            dal.SaveReview(fruitReview);
            Mock.Assert(mockContext);
        }

        [TestMethod]
        public void GetReview()
        {
            var dal = new FruitFinderDal(new FruitFinderContext(),
                Mock.Create<IDateTimeService>(),
                Mock.Create<ISecurityService>());
            var review = dal.GetReview(1);
            Assert.AreEqual(1, review.ReviewId);
        }

    }
}
