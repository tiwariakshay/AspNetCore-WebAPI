using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRespository _repository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRespository respository, IMapper mapper)
        {
            _repository = respository ?? throw new ArgumentNullException(nameof(respository));
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var citiesEntities = _repository.GetCities();
           
            // var result = new List<CityWithoutPointOfIntrestDto>();
            //foreach (var city in citiesEntities)
            //{
            //    result.Add(new CityWithoutPointOfIntrestDto
            //    {
            //        Id = city.Id,
            //        Description = city.Description,
            //        Name = city.Name
            //    });
            //}

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfIntrestDto>>(citiesEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfIntrest = false)
        {
            if (!_repository.CityExists(id))
            {
                return NotFound();
            }

            var city = _repository.GetCity(id, includePointsOfIntrest);
            if (includePointsOfIntrest)
            {
                return Ok(_mapper.Map<CityDTO>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointOfIntrestDto>(city));
        }
    }
}
