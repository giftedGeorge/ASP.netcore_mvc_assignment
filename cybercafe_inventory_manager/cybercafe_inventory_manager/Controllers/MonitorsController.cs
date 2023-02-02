using AutoMapper;
using cybercafe_inventory_manager.Data;
using cybercafe_inventory_manager.DTO.MonitorDtos;
using cybercafe_inventory_manager.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Controllers
{
    [Route("cybercafe_inventory/monitors")]
    [ApiController]
    public class MonitorsController : ControllerBase
    {
        private readonly IMonitorRepository _repository;
        private readonly IMapper _mapper;

        public MonitorsController(IMonitorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MonitorReadDto>> GetAllMonitors()
        {
            var monitors = _repository.GetAllMonitors();
            return Ok(_mapper.Map<MonitorReadDto>(monitors));
        }

        [HttpGet("{id}",Name ="GetMonitorById")]
        public ActionResult<MonitorReadDto> GetMonitorById(int id)
        {
            var monitor = _repository.GetMonitorById(id);
            if(monitor != null)
            {
                return Ok(_mapper.Map<MonitorReadDto>(monitor));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MonitorReadDto> CreateMonitor(MonitorMultipurposeDto newMonitorDetails)
        {
            var monitorModel = _mapper.Map<Monitor>(newMonitorDetails);
            _repository.CreateMonitor(monitorModel);
            _repository.SaveChanges();

            var monitorReadDto =  _mapper.Map<MonitorReadDto>(monitorModel);
            return CreatedAtRoute(nameof(GetMonitorById), new {Id=monitorReadDto.Id}, monitorReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMonitor(int id, MonitorMultipurposeDto monitorUpdateDetails)
        {
            var monitorModelFromRepo = _repository.GetMonitorById(id);
            if(monitorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(monitorUpdateDetails, monitorModelFromRepo);
            _repository.UpdateMonitor(monitorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMonitorUpdate(int id, JsonPatchDocument<MonitorMultipurposeDto> patchDetails)
        {
            var monitorModelFromRepo = _repository.GetMonitorById(id);
            if(patchDetails == null)
            {
                return NotFound();
            }

            var multipurposeDtoFormatOfMonitorRetrieved = _mapper.Map<MonitorMultipurposeDto>(monitorModelFromRepo);
            patchDetails.ApplyTo(multipurposeDtoFormatOfMonitorRetrieved, ModelState);
            if (!TryValidateModel(multipurposeDtoFormatOfMonitorRetrieved))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(multipurposeDtoFormatOfMonitorRetrieved, monitorModelFromRepo);
            _repository.UpdateMonitor(monitorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMonitor(int id)
        {
            var monitorModelFromRepo = _repository.GetMonitorById(id);
            if(monitorModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteMonitor(monitorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
