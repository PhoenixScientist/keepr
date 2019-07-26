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
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }

    // GET api/Vault
    [Authorize]
    [HttpGet]
    // [HttpGet("keeps/user/:userId")]
    public ActionResult<IEnumerable<Keep>> GetByUserId()
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        // value.userId = id;
        return Ok(_repo.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    // GET api/Vault/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // //GET api/vaults/:id/keeps
    // [HttpGet("{id}/keeps")]
    // public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetKeepsByVaultId(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    // POST api/Vault
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        value.UserId = id;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //POST api/vaults/:id/keeps
    [HttpPost("{id}/keeps")]
    public ActionResult<String> AddKeepToVault(int id, [FromBody] VaultKeep vaultKeep)
    {
      try
      {
        vaultKeep.VaultId = id;
        return Ok(_repo.AddKeepToVault(vaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // PUT api/Vault/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
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

    // DELETE api/Vault/5
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
