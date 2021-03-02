using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ProfilesController : ControllerBase
  {

    private readonly ProfilesService _service;
    private readonly VaultsService _vs;
    private readonly KeepsService _ks;

    public ProfilesController(ProfilesService service, VaultsService vs, KeepsService ks)
    {
      _service = service;
      _vs = vs;
      _ks = ks;
    }


    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _service.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // GET vaults by profile id







  }
}