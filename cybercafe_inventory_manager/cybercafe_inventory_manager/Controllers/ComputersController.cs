using AutoMapper;
using cybercafe_inventory_manager.Data;
using cybercafe_inventory_manager.DTO.ComputerDtos;
using cybercafe_inventory_manager.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Controllers
{
    [Route("cybercafe_inventory/computers")]
    [ApiController]
    public class ComputersController:ControllerBase
    {
        private readonly IComputerRepository _repository;
        private readonly IMapper _mapper;
        private readonly List<int> _noOfCoresOptions = new List<int> {1,2,4,8};

        public ComputersController(IComputerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockInventoryRepo _Repository = new MockInventoryRepo();

        [HttpGet]
        public ActionResult<IEnumerable<ComputerReadDto>> GetAllComputers()
        {
            var computers = _repository.GetAllComputers();

            return Ok(_mapper.Map<IEnumerable<ComputerReadDto>>(computers));
        }

        [HttpGet("{id}",Name ="GetComputerById")]//The name will be used to reference this method to retrieve the uri of the item in the post method.
        public ActionResult<ComputerReadDto> GetComputerById(int id)
        {
            var computer = _repository.GetComputerById(id);
            if(computer != null)
            {
                return Ok(_mapper.Map<ComputerReadDto>(computer));
            }
            return NotFound();
        }

        [HttpPost]
        //this will create a new item and return the Dto format of the created item
        public ActionResult<ComputerReadDto> CreateComputer(ComputerMultipurposeDto newComputerDetails)
        {
            if (!_noOfCoresOptions.Contains(newComputerDetails.number_of_cores))
            {
                ModelState.AddModelError("number_of_cores", "number_of_cores must be 1,2,4,or 8");
                return BadRequest(ModelState);
            }
            var computerModel = _mapper.Map<Computer>(newComputerDetails);//maps the new details into the format of our model for entry into the database.
            
            _repository.CreateComputer(computerModel);
            _repository.SaveChanges();

            var computerReadDto = _mapper.Map<ComputerReadDto>(computerModel);

            //to return the '201 created' message, readDto format of the created item, and add the item's location(uri) in the database to the header.
            return CreatedAtRoute(nameof(GetComputerById), new { Id = computerReadDto.Id }, computerReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComputer(int id, ComputerMultipurposeDto computerUpdateDetails)
        {
            var computerModelFromRepo = _repository.GetComputerById(id);
            if(computerModelFromRepo == null)
            {
                return NotFound();
            }

            if (!_noOfCoresOptions.Contains(computerUpdateDetails.number_of_cores))
            {
                ModelState.AddModelError("number_of_cores", "number_of_cores must be 1,2,4,or 8");
                return BadRequest(ModelState);
            }

            _mapper.Map(computerUpdateDetails, computerModelFromRepo);

            _repository.UpdateComputer(computerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialComputerUpdate(int id, JsonPatchDocument<ComputerMultipurposeDto> patchDetails)
        {
            var computerModelFromRepo = _repository.GetComputerById(id);
            if (computerModelFromRepo == null)
            {
                return NotFound();
            }

            var multipurposeDtoFormatOfComputerRetrieved = _mapper.Map<ComputerMultipurposeDto>(computerModelFromRepo);
            patchDetails.ApplyTo(multipurposeDtoFormatOfComputerRetrieved, ModelState);

            if (!TryValidateModel(multipurposeDtoFormatOfComputerRetrieved))
            {
                return ValidationProblem(ModelState);
            }

            if (!_noOfCoresOptions.Contains(multipurposeDtoFormatOfComputerRetrieved.number_of_cores))
            {
                ModelState.AddModelError("number_of_cores", "number_of_cores must be 1,2,4,or 8");
                return BadRequest(ModelState);
            }

            _mapper.Map(multipurposeDtoFormatOfComputerRetrieved, computerModelFromRepo);

            _repository.UpdateComputer(computerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComputer(int id)
        {
            var computerModelFromRepo = _repository.GetComputerById(id);
            if (computerModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteComputer(computerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
