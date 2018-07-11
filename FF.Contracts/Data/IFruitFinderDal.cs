using FF.Data.Models;

namespace FF.Contracts.Data
{
    public interface IFruitFinderDal
    {
        IReview SaveReview(IReview review);
    }
}
