using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRespository
    {
        IEnumerable<City> GetCities();

        City GetCity(int cityId, bool includePointsOfIntrest);

        IEnumerable<PointOfIntrest> GetPointsOfIntrest(int cityId);

        PointOfIntrest GetPointOfIntrestForCity(int cityId, int pointOfIntrestId);

        bool CityExists(int cityId);

        void AddPointOfIntrestForCity(int cityId, PointOfIntrest pointOfIntrest);

        void DeletePointOfIntrest(PointOfIntrest pointOfIntrest);

        bool Save();
    }
}
