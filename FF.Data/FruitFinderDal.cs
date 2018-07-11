using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FF.Data.Models;
using FF.Contracts.Data;
using FF.Contracts.Service;
using FF.Data.Helpers;
using FF.Data.Validators;

namespace FF.Data
{
    public class FruitFinderDal : IFruitFinderDal, IDisposable
    {
        #region constructor
        private IFruitFinderContext _context;
        private IDateTimeService _dateTimeService;
        private ISecurityService _securityService;

        public FruitFinderDal(
            IFruitFinderContext context,
            IDateTimeService dateTimeService,
            ISecurityService securityService)
        {
            _context = context;
            _dateTimeService = dateTimeService;
            _securityService = securityService;
        }
#endregion
        public IReview SaveReview(IReview review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review), "Review is required");

            var reviewEntity = (Review) review;

            AuditHelper.SetAuditFieldsOnSave(reviewEntity,
                _dateTimeService.UtcNow(),
                _securityService.CurrentUserId());

            ValidateReview(reviewEntity);

            AddReviewToContext(reviewEntity);

            _context.SaveChanges();

            return reviewEntity;
        }

        private void ValidateReview(Review review)
        {
            var issues = ReviewValidator.GetValidationIssues(review);
            if (!issues.Any())
                return;

            var message = new StringBuilder();

            message.AppendLine("There were validation issues with the review.");
            foreach (var issue in issues)
            {
                message.AppendLine(issue);
            }
            throw new ApplicationException(message.ToString());
        }

        private void AddReviewToContext(Review review)
        {
            _context.Reviews.Attach(review);
            _context.SetAddedOrModified(review, review.ReviewId);
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
        }

        public IEnumerable<Review> GetTopReviews(int numberToInclude)
        {
            return _context.Reviews
                .OrderByDescending(r => r.VoteTally)
                .Take(numberToInclude);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
