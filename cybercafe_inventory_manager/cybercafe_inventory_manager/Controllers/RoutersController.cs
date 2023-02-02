using AutoMapper;
using cybercafe_inventory_manager.Data;
using cybercafe_inventory_manager.DTO.RouterDtos;
using cybercafe_inventory_manager.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Controllers
{
    [Route("cybercafe_inventory/routers")]
    [ApiController]
    public class RoutersController : ControllerBase
    {
        private readonly IRouterRepository _repository;
        private readonly IMapper _mapper;

        public RoutersController(IRouterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RouterReadDto>> GetAllRouters()
        {
            var routers = _repository.GetAllRouters();
            return Ok(_mapper.Map<RouterReadDto>(routers));
        }

        [HttpGet("{id}",Name ="GetRouterById")]
        public ActionResult<RouterReadDto> GetRouterByid(int id)
        {
            var router = _repository.GetRouterById(id);
            if(router != null)
            {
                return Ok(_mapper.Map<RouterReadDto>(router));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<RouterReadDto> CreateRouter(RouterMultipurposeDto newRouterDetails)
        {
            var routerModel = _mapper.Map<Router>(newRouterDetails);
            _repository.CreateRouter(routerModel);
            _repository.SaveChanges();

            var routerReadDto = _mapper.Map<RouterReadDto>(routerModel);
            return CreatedAtRoute(nameof(GetRouterByid), new {Id = routerReadDto.Id}, routerReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRouter(int id, RouterMultipurposeDto routerUpdateDetails)
        {
            var routerModelFromRepo = _repository.GetRouterById(id);
            if( routerModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(routerUpdateDetails, routerModelFromRepo);
            _repository.UpdateRouter(routerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialRouterUpdate(int id, JsonPatchDocument<RouterMultipurposeDto> patchDetails)
        {
            var routerModelFromRepo = _repository.GetRouterById(id);
            if(routerModelFromRepo == null)
            {
                return NotFound();
            }

            var multipurposeDtoFormatOfRouterRetrieved = _mapper.Map<RouterMultipurposeDto>(routerModelFromRepo);
            patchDetails.ApplyTo(multipurposeDtoFormatOfRouterRetrieved, ModelState);
            if (!TryValidateModel(multipurposeDtoFormatOfRouterRetrieved))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(multipurposeDtoFormatOfRouterRetrieved, routerModelFromRepo);
            _repository.UpdateRouter(routerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRouter(int id)
        {
            var routerModelFromRepo = _repository.GetRouterById(id);
            if( routerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRouter(routerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
