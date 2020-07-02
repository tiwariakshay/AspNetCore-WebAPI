using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRespository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCity(int cityId, bool includePointsOfIntrest)
        {
            if (includePointsOfIntrest)
            {
                return _context.Cities.Include(i => i.PointOfIntrests).FirstOrDefault(x => x.Id == cityId);
            }
            else
            {
                return _context.Cities.FirstOrDefault(x => x.Id == cityId);

            }
        }

        public PointOfIntrest GetPointOfIntrestForCity(int cityId, int pointOfIntrestId)
        {
            return _context.PointOfIntrests.FirstOrDefault(x => x.CityId == cityId && x.Id == pointOfIntrestId);
        }

        public IEnumerable<PointOfIntrest> GetPointsOfIntrest(int cityId)
        {
            return _context.PointOfIntrests.Where(x => x.CityId == cityId).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(x => x.Id == cityId);
        }

        public void AddPointOfIntrestForCity(int cityId, PointOfIntrest pointOfIntrest)
        {
            var city = GetCity(cityId, false);
            city.PointOfIntrests.Add(pointOfIntrest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeletePointOfIntrest(PointOfIntrest pointOfIntrest)
        {
            _context.PointOfIntrests.Remove(pointOfIntrest);
        }
    }
}
