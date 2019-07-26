using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/VaultKeep/5
    // [HttpGet("{id}")]
    // public ActionResult<VaultKeep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    // GET api/VaultKeep/5
    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<VaultKeep> Get(int vaultId)
    {
      try
      {
        var useId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetByVaultId(vaultId, useId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/VaultKeeps
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep value)
    {
      try
      {
        var useId = HttpContext.User.FindFirstValue("Id");
        value.UserId = useId;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // PUT api/Vault/5
    [HttpPut("{id}")]
    public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep value)
    {
      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/Vaultkeep/5
    [Authorize]
    [HttpPut]
    public ActionResult<String> Put(VaultKeep objectvalue)
    {
      try
      {
        var useId = HttpContext.User.FindFirstValue("Id");
        objectvalue.UserId = useId;
        return Ok(_repo.Delete(objectvalue));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
