using AutoMapper;
using FF.Contracts.Dto;
using FF.Data.Models;

namespace FF.Service
{
    public class EntityMapper
    {
        private static IMapper _mapper;


        private EntityMapper()
        {
            
        }

        public static IMapper GetEntityMapper()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FruitReview, IReview>();
                });
                _mapper = config.CreateMapper();
            }
            return _mapper;
        }
    }
}
