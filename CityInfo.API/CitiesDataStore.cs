using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDTO> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO()
                {
                    Id = 1,
                    Name = "Toronto",
                    Description = "Canada Capital City",
                    PointOfIntrests = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 1,
                            Name = "CN Tower",
                            Description = "Iconic tower with revolving restaurant"
                        },
                         new PointOfIntrestDto()
                        {
                            Id = 2,
                            Name = "Royal Museum",
                            Description = "Huge range of  cultures"
                        },new PointOfIntrestDto()
                        {
                            Id = 3,
                            Name = "Casa Loma",
                            Description = "Stately castle and gardens"
                        }
                    }
                },
                new CityDTO()
                {
                    Id = 2,
                    Name = "Brampton",
                    Description = "Majotiry of Indian Society lives",
                     PointOfIntrests = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 1,
                            Name = "Humber River",
                            Description = "River, Marsh, park and garden"
                        },
                         new PointOfIntrestDto()
                        {
                            Id = 2,
                            Name = "Heart Lake",
                            Description = "Wetlands and Ziplines"
                        }
                    }
                },
                new CityDTO()
                {
                    Id = 3,
                    Name = "Calgary",
                    Description = "The place with scenic beauty",
                     PointOfIntrests = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 1,
                            Name = "Calgary Tower",
                            Description = "City Vitas and revolving restaurant"
                        },
                         new PointOfIntrestDto()
                        {
                            Id = 2,
                            Name = "Calgary Zoo",
                            Description = "Live animals and dianasaur displays"
                        }
                    }
                },
            };
        }
    }
}
