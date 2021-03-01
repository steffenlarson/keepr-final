using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
  public class VaultKeepsController : ControllerBase
  {

    private readonly VaultKeepsService _service;

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }



    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> Create([FromBody] VaultKeep vk)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Create(vk, userInfo.Id);
        return Ok("success");
      }
      catch (Forbidden e)
      {
        return StatusCode(StatusCodes.Status403Forbidden, e.Message);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete 
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }




  }
}