using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeep> GetALL()
    {
      return _db.Query<VaultKeep>("SELECT * FROM keeps");
    }

    // public VaultKeep GetById(int id)
    // {
    //   string query = "SELECT * FROM vaultkeeps WHERE id = @id";
    //   VaultKeep VK = _db.QueryFirstOrDefault<VaultKeep>(query, new { id });
    //   if (VK == null) throw new Exception("Invalid Id");
    //   return VK;
    // }
    public IEnumerable<Keep> GetByVaultId(int vaultId, string useId)
    {
      string query = @"SELECT * FROM vaultkeeps vk
       INNER JOIN keeps k ON k.id = vk.KeepId 
       WHERE (vaultId = @vaultId AND vk.userId = @useId) ";
      IEnumerable<Keep> kdata = _db.Query<Keep>(query, new { vaultId, useId });
      if (kdata == null) throw new Exception("Invalid Id");
      return kdata;
    }

    public VaultKeep Create(VaultKeep value)
    {
      string query = @"
            INSERT INTO vaultkeeps (keepId, vaultId, userId)
                    VALUES (@KeepId, @VaultId, @UserId);
                    SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }


    public VaultKeep Update(VaultKeep value)
    {
      string query = @"
            UPDATE keeps
            SET
                vaultId = @VaultId,
                keepId = @KeepId,
                userId = @UserId
            WHERE id = @Id;            
            SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(query, value);
    }

    public string Delete(VaultKeep objectvalue)
    {
      string query = @"DELETE FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId)";
      int changedRows = _db.Execute(query, objectvalue);
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted VaultKeep";

    }

  }
}