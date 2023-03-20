using Microsoft.AspNetCore.Mvc;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Controllers
{
    [Route("/api/villaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
    }
}
