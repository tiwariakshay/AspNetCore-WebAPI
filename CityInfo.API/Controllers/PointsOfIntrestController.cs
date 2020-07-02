using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofintrest")]
    public class PointsOfIntrestController : ControllerBase
    {
        private readonly ILogger<PointsOfIntrestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRespository _repository;
        private readonly IMapper _mapper;

        public PointsOfIntrestController(ILogger<PointsOfIntrestController> logger, IMailService mailService, ICityInfoRespository repository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPointsOfIntrest(int cityId)
        {
            if(!_repository.CityExists(cityId))
            {
                _logger.LogInformation($"City with Id {cityId} wasn't found.");
                return NotFound();
            }
            var pointOfRepositoryForCity = _repository.GetPointsOfIntrest(cityId);
            
            return Ok(_mapper.Map<IEnumerable<PointOfIntrestDto>>(pointOfRepositoryForCity));
        }

        [HttpGet("{id}", Name = "GetPointOfIntrest")]
        public IActionResult GetPointsOfIntrest(int cityId, int id)
        {
            if (!_repository.CityExists(cityId))
            {
                _logger.LogInformation($"City with Id {cityId} wasn't found.");
                return NotFound();
            }

            var pointOfIntrest = _repository.GetPointOfIntrestForCity(cityId, id);
            return Ok(_mapper.Map<PointOfIntrestDto>(pointOfIntrest));
        }

        [HttpPost]
        public IActionResult CreatePointOfIntrest([FromBody] PointsOfCreationForCreationDto pointsOfCreationForCreationDto, int cityId)
        {
            if (pointsOfCreationForCreationDto.Name == pointsOfCreationForCreationDto.Description)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the Name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_repository.CityExists(cityId))
                return NotFound();

            var finalPointOfIntrest = _mapper.Map<Entities.PointOfIntrest>(pointsOfCreationForCreationDto);

            _repository.AddPointOfIntrestForCity(cityId, finalPointOfIntrest);
            _repository.Save();

            var createdPointOfIntrestDTO = _mapper.Map<Models.PointOfIntrestDto>(finalPointOfIntrest);

            return CreatedAtRoute("GetPointOfIntrest", new { cityId, id = createdPointOfIntrestDTO.Id }, createdPointOfIntrestDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfIntrest([FromBody] PointsOfIntrestForUpdateDTO pointsOfIntrestForUpdateDto, int cityId, int id)
        {
            if (pointsOfIntrestForUpdateDto.Name == pointsOfIntrestForUpdateDto.Description)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the Name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_repository.CityExists(cityId))
                return NotFound();

            var pointOfIntrest = _repository.GetPointOfIntrestForCity(cityId, id);

            if (pointOfIntrest == null)
                return NotFound();

            _mapper.Map(pointsOfIntrestForUpdateDto, pointOfIntrest);

            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdatePointOfIntrest([FromBody] JsonPatchDocument<PointsOfIntrestForUpdateDTO> patchDoc, int cityId, int id)
        {
            if (!_repository.CityExists(cityId))
                return NotFound();

            var pointOfIntrest = _repository.GetPointOfIntrestForCity(cityId, id);

            if (pointOfIntrest == null)
                return NotFound();

            var pointOfIntrestToPatch = _mapper.Map<PointsOfIntrestForUpdateDTO > (pointOfIntrest);

            patchDoc.ApplyTo(pointOfIntrestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (pointOfIntrestToPatch.Name == pointOfIntrestToPatch.Description)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the Name.");
            }

            if (!TryValidateModel(pointOfIntrestToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(pointOfIntrestToPatch, pointOfIntrest);

            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfIntrest(int cityId, int id)
        {
            if (!_repository.CityExists(cityId))
                return NotFound();

            var pointOfIntrest = _repository.GetPointOfIntrestForCity(cityId, id);

            if (pointOfIntrest == null)
                return NotFound();

            _repository.DeletePointOfIntrest(pointOfIntrest);
            _repository.Save();

            _mailService.SendEmail();

            return NoContent();

        }
    }
}
