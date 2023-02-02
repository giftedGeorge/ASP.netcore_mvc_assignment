using AutoMapper;
using cybercafe_inventory_manager.Data;
using cybercafe_inventory_manager.DTO.KeyboardDtos;
using cybercafe_inventory_manager.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Controllers
{
    [Route("cybercafe_inventory/keyboards")]
    [ApiController]
    public class KeyboardsController : ControllerBase
    {
        private readonly IKeyboardRepository _repository;
        private readonly IMapper _mapper;
        private readonly List<string> _keyboardTypeOptions = new List<string> {"wireless", "wired"};
        private readonly List<string> _numericKeypadOptions = new List<string> { "yes", "no" };
        private readonly List<string> _hasBacklightOptions = new List<string> { "yes", "no" };


        public KeyboardsController(IKeyboardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KeyboardReadDto>> GetAllKeyboards()
        {
            var keyboards = _repository.GetAllKeyboards();
            return Ok(_mapper.Map<KeyboardReadDto>(keyboards));
        }

        [HttpGet("{id}", Name ="GetKeyboardById")]
        public ActionResult<KeyboardReadDto> GetKeyboardById(int id)
        {
            var keyboard = _repository.GetKeyboardById(id);
            if(keyboard != null)
            {
                return Ok(_mapper.Map<KeyboardReadDto>(keyboard));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<KeyboardReadDto> CreateKeyboard(KeyboardMultipurposeDto newKeyboardDetails)
        {
            if(!_keyboardTypeOptions.Contains(newKeyboardDetails.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be wireless or wired");
                return BadRequest(ModelState);
            }

            if (!_numericKeypadOptions.Contains(newKeyboardDetails.has_numeric_keypad.ToLower()))
            {
                ModelState.AddModelError("has_numeric_keypad", "has_numeric_keypad must be yes or no");
                return BadRequest(ModelState);
            }

            if (!_hasBacklightOptions.Contains(newKeyboardDetails.has_backlight.ToLower()))
            {
                ModelState.AddModelError("has_backlight", "has_backlight must be yes or no");
                return BadRequest(ModelState);
            }

            var keyboardModel = _mapper.Map<Keyboard>(newKeyboardDetails);
            _repository.CreateKeyboard(keyboardModel);
            _repository.SaveChanges();

            var keyboardReadDto = _mapper.Map<KeyboardReadDto>(keyboardModel);

            return CreatedAtRoute(nameof(GetKeyboardById), new {Id = keyboardReadDto.Id}, keyboardReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateKeyboard(int id, KeyboardMultipurposeDto keyboardUpdateDetails)
        {
            if (!_keyboardTypeOptions.Contains(keyboardUpdateDetails.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be wireless or wired");
                return BadRequest(ModelState);
            }

            if (!_numericKeypadOptions.Contains(keyboardUpdateDetails.has_numeric_keypad.ToLower()))
            {
                ModelState.AddModelError("has_numeric_keypad", "has_numeric_keypad must be yes or no");
                return BadRequest(ModelState);
            }

            if (!_hasBacklightOptions.Contains(keyboardUpdateDetails.has_backlight.ToLower()))
            {
                ModelState.AddModelError("has_backlight", "has_backlight must be yes or no");
                return BadRequest(ModelState);
            }


            var keyboardModelFromRepo = _repository.GetKeyboardById(id);
            if(keyboardModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(keyboardUpdateDetails, keyboardModelFromRepo);
            _repository.UpdateKeyboard(keyboardModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult PartialKeyboardUpdate(int id, JsonPatchDocument<KeyboardMultipurposeDto> patchDetails)
        {
            var keyboardModelFromRepo = _repository.GetKeyboardById(id);
            if(keyboardModelFromRepo == null)
            {
                return NotFound();
            }

            var multipurposeDtoFormatOfKeyboardRetrieved = _mapper.Map<KeyboardMultipurposeDto>(keyboardModelFromRepo);
            if (!_keyboardTypeOptions.Contains(multipurposeDtoFormatOfKeyboardRetrieved.type.ToLower()))
            {
                ModelState.AddModelError("type", "type must be wireless or wired");
                return BadRequest(ModelState);
            }

            if (!_numericKeypadOptions.Contains(multipurposeDtoFormatOfKeyboardRetrieved.has_numeric_keypad.ToLower()))
            {
                ModelState.AddModelError("has_numeric_keypad", "has_numeric_keypad must be yes or no");
                return BadRequest(ModelState);
            }

            if (!_hasBacklightOptions.Contains(multipurposeDtoFormatOfKeyboardRetrieved.has_backlight.ToLower()))
            {
                ModelState.AddModelError("has_backlight", "has_backlight must be yes or no");
                return BadRequest(ModelState);
            }


            patchDetails.ApplyTo(multipurposeDtoFormatOfKeyboardRetrieved, ModelState);
            if (!TryValidateModel(multipurposeDtoFormatOfKeyboardRetrieved))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(multipurposeDtoFormatOfKeyboardRetrieved, keyboardModelFromRepo);
            _repository.UpdateKeyboard(keyboardModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteKeyboard(int id)
        {
            var keyboardModelFromRepo = (_repository.GetKeyboardById(id));
            if(keyboardModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteKeyboard(keyboardModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
