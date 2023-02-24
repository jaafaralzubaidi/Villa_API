using Microsoft.AspNetCore.Mvc;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models.Dto;

namespace Villa_VillaAPI.Controllers
{

    // ASP.NET MVC     : Controller
    // ASP.NET Web API : ControllerBase
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        //[httpget("id")]
        [HttpGet("{id:int}", Name = "GetVilla")] // more explicit
        // Use ProducesResponeType to get rid of undocumented in swagger 
        //[ProducesResponseType(200, Type = typeof(VillaDTO))]   //OK             insteaf of using in fun declaration  =>    public ActionResult<VillaDTO> GetVilla(int id)
        //[ProducesResponseType(404)]                            //NotFound
        //[ProducesResponseType(400)]                            //BadRequest
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult GetVilla(int id)
        {
            if (id == 0)
                return BadRequest();
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();

            return Ok(villa);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
        {
            //will execure only if ModalState is valid (in this case, it must have a name field
            // check if name alreay exists
            if (VillaStore.villaList.FirstOrDefault(x => x.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
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

            return CreatedAtRoute("GetVilla", new {id = villaDTO.Id }, villaDTO);
        }
    }
}
