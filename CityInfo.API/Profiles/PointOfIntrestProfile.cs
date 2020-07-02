using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Profiles
{
    public class PointOfIntrestProfile : Profile
    {
        public PointOfIntrestProfile()
        {
            CreateMap<Entities.PointOfIntrest, Models.PointOfIntrestDto>();
            CreateMap<Models.PointsOfCreationForCreationDto, Entities.PointOfIntrest>();
            CreateMap<Models.PointsOfIntrestForUpdateDTO, Entities.PointOfIntrest>().ReverseMap();
        }
    }
}
