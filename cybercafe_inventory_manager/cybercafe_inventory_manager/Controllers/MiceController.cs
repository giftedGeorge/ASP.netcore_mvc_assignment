using AutoMapper;
using cybercafe_inventory_manager.Data;
using cybercafe_inventory_manager.DTO.MouseDtos;
using cybercafe_inventory_manager.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Controllers
{
    [Route("cybercafe_inventory/Mice")]
    [ApiController]
    public class MiceController : ControllerBase
    {
        private readonly IMouse _repository;
        private readonly IMapper _mapper;
        private readonly List<string> _mouseTypeOptions = new List<string> {"yes", "no"};

        public MiceController(IMouse repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MouseReadDto>> GetAllMIce()
        {
            var mice = _repository.GetAllMice();
            return Ok(_mapper.Map<MouseReadDto>(mice));
        }

        [HttpGet("{id}", Name ="GetMiceById")]
        public ActionResult<MouseReadDto> GetMouseById(int id)
        {
            var mouse = _repository.GetMouseById(id);
            if(mouse != null)
            {
                return Ok(_mapper.Map<MouseReadDto>(mouse));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MouseReadDto> CreateMouse(MouseMultipurposeDto newMouseDetails)
        {
            if (!_mouseTypeOptions.Contains(newMouseDetails.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be yes or no");
                return BadRequest(ModelState);
            }

            var mouseModel = _mapper.Map<Mouse>(newMouseDetails);
            _repository.CreateMouse(mouseModel);
            _repository.SaveChanges();

            var mouseReadDto = _mapper.Map<MouseReadDto>(mouseModel);
            return CreatedAtRoute(nameof(GetMouseById), new { Id = mouseReadDto.Id }, mouseReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult<MouseReadDto> UpdateMouse(int id, MouseMultipurposeDto mouseUpdateDetails)
        {
            if (!_mouseTypeOptions.Contains(mouseUpdateDetails.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be yes or no");
                return BadRequest(ModelState);
            }

            var mouseModelFromRepo = _repository.GetMouseById(id);
            if(mouseModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(mouseUpdateDetails, mouseModelFromRepo);
            _repository.UpdateMouse(mouseModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMouseUpdate(int id, JsonPatchDocument<MouseMultipurposeDto> patchDetails)
        {
            var mouseModelFromRepo = _repository.GetMouseById(id);
            if(mouseModelFromRepo == null)
            {
                return NotFound();
            }

            var multipurposeDtoFormatOfMouseRetrieved = _mapper.Map<MouseMultipurposeDto>(mouseModelFromRepo);
            if (!_mouseTypeOptions.Contains(multipurposeDtoFormatOfMouseRetrieved.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be yes or no");
                return BadRequest(ModelState);
            }

            patchDetails.ApplyTo(multipurposeDtoFormatOfMouseRetrieved, ModelState);
            if (!TryValidateModel(multipurposeDtoFormatOfMouseRetrieved))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(multipurposeDtoFormatOfMouseRetrieved, mouseModelFromRepo);
            _repository.UpdateMouse(mouseModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMouse(int id)
        {
            var mouseModelFromRepo = _repository.GetMouseById(id);
            if( mouseModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteMouse(mouseModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
