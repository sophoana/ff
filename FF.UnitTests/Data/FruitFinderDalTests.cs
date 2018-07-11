using System;
using System.Collections.Generic;
using System.Linq;
using FF.Contracts.Service;
using FF.Data;
using FF.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;
using FluentAssertions;

namespace FF.UnitTests.Data
{
    public class FruitFinderDalBuilder
    {
        public const string SecurityServiceUserName = "test";
        public const int SecurityServiceUserId = 1;

        private IFruitFinderContext _context = EntityFrameworkMock
                .Create<IFruitFinderContext>();

        private IDateTimeService _dateTimeService = Mock.CreateLike<IDateTimeService>(
            dts => dts.UtcNow() == new DateTime(2000,1,1));

        private ISecurityService _securityService = Mock.CreateLike<ISecurityService>(
            ss => ss.CurrentUser() == SecurityServiceUserName &&
                  ss.CurrentUserId() == SecurityServiceUserId);

        public FruitFinderDalBuilder WithContext(IFruitFinderContext context)
        {
            _context = context;
            return this;
        }

        public FruitFinderDalBuilder WithDateTime(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
            return this;
        }

        public FruitFinderDalBuilder WithSecurityService(ISecurityService securityService)
        {
            _securityService = securityService;
            return this;
        }

        public FruitFinderDal Build()
        {
            return new FruitFinderDal(_context, _dateTimeService, _securityService);
        }

        public IDateTimeService GetDateTimeService()
        {
            return _dateTimeService;
        }

        public Review MakeReview()
        {
            var review = new Review();
            review.DateTimeService = _dateTimeService;
            review.FruitId = 1;
            return review;
        }
    }

    [TestClass]
    public class FruitFinderDalTests
    {
        [TestMethod] //A value test
        public void GettingTopFiveReviews_WhenFiveExist_ReturnsFiveInDescendingOrder()
        {
            //Arrange
            var mockContext = Mock.Create<FruitFinderContext>().PrepareMock();
            var reviews = new List<Review>();
            var builder = new FruitFinderDalBuilder().WithContext(mockContext);
            var numberToInclude = 5;
            for (int i = 0; i < numberToInclude * 2; i++)
            {
                var review = builder.MakeReview();
                review.VoteTally = i;
                reviews.Add(review);
            }
            mockContext.Reviews.Bind(reviews);
            var dal = builder.Build();

            //Act
            var result = dal.GetTopReviews(numberToInclude);

            //Assert
            result.Count().Should().Be(numberToInclude, 
                "the list should have " + numberToInclude + " reviews");
            result.Should().BeInDescendingOrder(x => x.VoteTally, 
                "the reviews should be in descending order by VoteTally");
        }

        [TestMethod]
        public void SavingAReview_WhenUpdatingIt_UpdatesTheUpdatedWhenAndBy()
        {
            //Arrange
            var builder = new FruitFinderDalBuilder();
            var dal = builder.Build();
            var dateTimeService = builder.GetDateTimeService();
            var review = builder.MakeReview();
            review.ReviewId = 1;
            review.UpdatedBy = FruitFinderDalBuilder.SecurityServiceUserId + 1;
            review.UpdatedWhen = dateTimeService.UtcNow().AddDays(-1);

            //Act
            dal.SaveReview(review);

            //Assert
            review.UpdatedWhen.ShouldBeEquivalentTo(dateTimeService.UtcNow(),
                "the updated date should be set to UtcNow when the review is saved");
            review.UpdatedBy.ShouldBeEquivalentTo(FruitFinderDalBuilder.SecurityServiceUserId,
                "the updated by should be set to the current user when a review is saved");

        }

        [TestMethod]
        public void SavingAReview_WhenSuccessful_CallsContextSaveChanges()
        {
            //Arrange
            var mockContext = EntityFrameworkMock.Create<IFruitFinderContext>();
            Mock.Arrange(() => mockContext.SaveChanges()).OccursOnce();
            var builder = new FruitFinderDalBuilder().WithContext(mockContext);
            var dal = builder.Build();
            var review = builder.MakeReview();

            //Act
            dal.SaveReview(review);

            //Assert
            Mock.Assert(mockContext);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SavingAReview_WhenTheReviewIsNull_RaisesAnArgumentNullException()
        {
            //Arrange
            var builder = new FruitFinderDalBuilder();
            var dal = builder.Build();
            Review review = null;

            //Act
            dal.SaveReview(review);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SavingAReview_WhenNoFruitIncluded_RaisesAnApplicationException()
        {
            //Arrange
            var builder = new FruitFinderDalBuilder();
            var dal = builder.Build();
            var review = builder.MakeReview();
            review.FruitId = 0;
            review.Fruit = null;

            //Act
            dal.SaveReview(review);
        }

        [TestMethod]
        public void SavingAReview_WhenItIsNew_SetsTheAddedByAndWhen()
        {
            //Arrange
            var builder = new FruitFinderDalBuilder();
            var dal = builder.Build();
            var review = builder.MakeReview();
            var defaultDate = builder.GetDateTimeService().UtcNow().AddDays(-1);
            review.AddedWhen = defaultDate;

            //Act
            var result = dal.SaveReview(review);

            //Assert
            result.AddedBy.Should().BeGreaterThan(0, "the added by Id should be set.");
            result.AddedWhen.Should().BeAfter(defaultDate, "the added when should be set.");
        }

    }
}
