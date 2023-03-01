using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Logging;
using Villa_VillaAPI.Models.Dto;

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
        public VillaAPIController()
        {
            
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //_logger.LogInformation("Getting all Villas information");
            //_logger.Log("Getting all Villas information", "");      //custom logger
            return Ok(VillaStore.villaList);
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

        public ActionResult GetVilla(int id)
        {
            if (id == 0) {
                //_logger.Log("Get Villa error with id: " + id, "error"); // custom Logger
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();

            return Ok(villa);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //will execure only if ModalState is valid (in this case, it must have a name field
            // check if name alreay exists
            if (VillaStore.villaList.FirstOrDefault(x => x.Name.ToLower() == villaDTO.Name.ToLower()) != null) {   // first parameter in AddModelError() must be unique
                ModelState.AddModelError("CustomError", "Villa alreay Exists!");
                return BadRequest(ModelState);
            }



            if (villaDTO == null)
                return BadRequest(villaDTO);
            // when creating the id should be zero
            if (villaDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);
            // fetching the next id
            villaDTO.Id = VillaStore.villaList.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);

            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }



        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteVilla(int id)    // since this function is not retuning anything, with IActionResult don't need to define the return type
        {
            if (id == 0)
                return BadRequest();
            
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if(villa == null) 
                return NotFound();
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }



        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult updateVilla(int id, [FromBody]VillaDTO villaDTO)
        {   
            if(villaDTO == null || id != villaDTO.Id) 
                return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            villa.Name = villaDTO.Name;
            villa.Occupancy = villaDTO.Occupancy;
            villa.Sqft = villaDTO.Sqft;

            return NoContent();
        }



        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult updatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id  == 0)
                return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if(villa == null)
                return BadRequest();


            patchDTO.ApplyTo(villa, ModelState); // apply to villa and if any errors store them in ModelState

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

    }
}
