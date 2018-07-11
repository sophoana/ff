using System;
using FF.Contracts.Service;
using FF.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using FluentAssertions;

namespace FF.UnitTests.Data.Models
{
    [TestClass]
    public class ReviewTests
    {
        private IDateTimeService _dateTimeService = Mock.CreateLike<IDateTimeService>(
            dts => dts.UtcNow() == new DateTime(2000, 1, 1));

        private Review MakeReview()
        {
            var review = new Review();
            review.DateTimeService = _dateTimeService;
            return review;
        }

        /// <summary>
        /// example of what not to do
        /// </summary>
        [TestMethod]
        public void GetFreshnessScore_PassingInVotes_ReturnsANumber()
        {
            //Arrange
            var review = MakeReview();
            var votes = 5;

            //Act
            var result = review.CalculateFreshnessScore(votes);

            //Assert
            result.GetType().Should().Be(typeof(double));
        }

        [TestMethod]
        public void GetFreshnessScore_WhenMoreThanOneVotes_ReturnsMoreThanZero()
        {
            //Arrange
            var review = MakeReview();
            var votes = 2;

            //Act
            var result = review.CalculateFreshnessScore(votes);

            //Assert
            result.Should().BeGreaterThan(0d, "the votes were greater than 1.");
        }

        [TestMethod]
        public void GetFreshnessScore_WhenOnlyOneVote_ReturnsZero()
        {
            //Arrange
            var review = MakeReview();
            var votes = 1;

            //Act
            var result = review.CalculateFreshnessScore(votes);

            //Assert
            result.Should().BeApproximately(0, 0.001, "one vote makes the numerator zero.");
        }

        [TestMethod]
        public void GetFreshnessScore_WhenNegativeVotes_ReturnsLessThanZero()
        {
            //Arrange
            var review = MakeReview();
            var votes = -1;

            //Act
            var result = review.CalculateFreshnessScore(votes);

            //Assert
            result.Should().BeLessThan(0d, "the votes were less than zero.");
        }
    }
}
