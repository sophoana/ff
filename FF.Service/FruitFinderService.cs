using FF.Contracts.Dto;
using FF.Contracts.Service;
using NLog;
using System;
using AutoMapper;
using FF.Contracts.Data;
using FF.Data.Models;

namespace FF.Service
{
    public class FruitFinderService : IFruitFinderService
    {
        private IFruitFinderDal _fruitFinderDal;
        private ILocationService _locationService;
        private ILogger _log;
        private IMapper _mapper;

        public FruitFinderService(IFruitFinderDal fruitFinderDal, ILocationService locationService, ILogger log, IMapper mapper)
        {
            _fruitFinderDal = fruitFinderDal;
            _locationService = locationService;
            _log = log;
            _mapper = mapper;
        }


        public FruitReview SaveReview(FruitReview fruitReview)
        {
            if (fruitReview == null)
                throw new ArgumentException("Missing required parameter", nameof(fruitReview));

            _log.Debug("SaveReview for ReviewId {0}, FruitId {1}", fruitReview.ReviewId, fruitReview.FruitId);

            var entityReview = _fruitFinderDal.SaveReview(_mapper.Map<IReview>(fruitReview));

            _log.Debug("SaveReview complete");
            return _mapper.Map<FruitReview>(entityReview);
        }

    }
}
