using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Logging;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.Dto;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Controllers
{

    // ASP.NET MVC     : Controller
    // ASP.NET Web API : ControllerBase
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        //private readonly ILogger<VillaAPIController> _logger; // build-in logger
        //private readonly ILogging _logger;      // custom dependency injection
        // Because of independence injection
        // .NET core will provide the implementation of in _logger
        // we don't have to instantiate the class
        //public VillaAPIController(ILogger<VillaAPIController> logger)
        //public VillaAPIController(ILogging logger)
        //{
        //    _logger = logger;
        //}

        // Default

        private readonly IVillaRepository _dbVilla;  // added it to builder.Services.... in Program.cs
        private readonly IMapper _mapper;           // added it to builder.Services.... in program.cs
        
        public VillaAPIController(IVillaRepository dbVilla, IMapper mapper) // dependency injection
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()  // with async everyting will be wrapped in Task<>
        {
            //_logger.LogInformation("Getting all Villas information");
            //_logger.Log("Getting all Villas information", "");      //custom logger
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            return Ok( _mapper.Map<List<VillaDTO>>(villaList) );
        }

        //[httpget("id")]
        [HttpGet("{id:int}", Name = "GetVilla")] // more explicit
        // Use ProducesResponeType to get rid of undocumented in swagger 
        //[ProducesResponseType(200, Type = typeof(VillaDTO))]   //OK             insteaf of using in fun declaration  =>    public ActionResult<VillaDTO> GetVilla(int id)
        //[ProducesResponseType(404)]                            //NotFound
        //[ProducesResponseType(400)]                            //BadRequest
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0) {
                //_logger.Log("Get Villa error with id: " + id, "error"); // custom Logger
                return BadRequest();
            }

            var villa = await _dbVilla.GetAsync(x => x.Id == id); // no need to write SQL entiryFramework will take care of that

            if (villa == null)
                return NotFound();

            return Ok(_mapper.Map<VillaDTO>(villa));

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {

            // check if name alreay exists. it will only if ModalState is valid (in this case, it must have a name field)
            if (await _dbVilla.GetAsync(x => x.Name.ToLower() == createDTO.Name.ToLower()) != null) {    
                ModelState.AddModelError("CustomError", "Villa alreay Exists!");  // first parameter in AddModelError() must be unique
                return BadRequest(ModelState);
            }



            if (createDTO == null)
                return BadRequest(createDTO);
            // when creating the id should be zero
            //if (villadto.id > 0)
            //    return StatusCode(StatusCodes.Status500InternalServerError);

            // manual convertion from villaDTO to Villa
            Villa model = _mapper.Map<Villa>(createDTO);
            //Villa model = new ()
            //{
            //    Amenity = createDTO.Amenity,
            //    Details = createDTO.Details,
            //    ImageUrl = createDTO.ImageUrl,
            //    Name = createDTO.Name,
            //    Occupancy = createDTO.Occupancy,
            //    Rate = createDTO.Rate,
            //    Sqft = createDTO.Sqft,
            //};
            await _dbVilla.CreateAsync(model); 
            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }



        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteVilla(int id)    // since this function is not retuning anything, with IActionResult don't need to define the return type
        {
            if (id == 0)
                return BadRequest();
            
            var villa = await _dbVilla.GetAsync(x => x.Id == id);

            if(villa == null) 
                return NotFound();

            await _dbVilla.RemoveAsync(villa);
            return NoContent();
        }



        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
        {   
            if(updateDTO == null || id != updateDTO.Id) 
                return BadRequest();

            Villa model = _mapper.Map<Villa>(updateDTO);

            await _dbVilla.UpdateAsync(model);
            return NoContent();
        }



        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id  == 0)
                return BadRequest();


            
            var villa = await _dbVilla.GetAsync((x => x.Id == id), tracked: false);

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);   // mapping from Villa to VillaUpateDTO


            if(villa == null)
                return BadRequest();

            patchDTO.ApplyTo(villaDTO, ModelState); // apply patch to villa and if any errors store them in ModelState

            Villa model = _mapper.Map<Villa>(villaDTO);


            await _dbVilla.UpdateAsync(model);


            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

    }
}
