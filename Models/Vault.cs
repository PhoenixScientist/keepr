using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // public int Contents { get; set; }
    public string UserId { get; set; }
  }

}