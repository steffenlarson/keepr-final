using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {

    private readonly VaultsService _vs;
    private readonly ProfilesService _ps;

    private readonly KeepsService _ks;

    public VaultsController(VaultsService vs, ProfilesService ps, KeepsService ks)
    {
      _vs = vs;
      _ps = ps;
      _ks = ks;
    }




    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_vs.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> Get(int id)
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();

      if (userInfo == null)
      {
        try
        {
          return Ok(_vs.GetPublic(id));
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        };
      }
      else
      {
        try
        {
          return Ok(_vs.Get(id, userInfo.Id));
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        };
      }
    }





    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Post([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        Vault created = _vs.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editData.Id = id;
        editData.Creator = userInfo;
        return Ok(_vs.Edit(editData, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vs.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [HttpGet("{vaultId}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetVaultKeeps(int vaultId)
    {
      try
      {
        return Ok(_ks.GetKeepsByVaultId(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}