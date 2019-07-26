using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> Get(string id)
    {
      // return _db.Query<Vault>("SELECT * FROM vaults");
      string query = @"
            SELECT * FROM vaults
            WHERE userId = @id
            ";
      return _db.Query<Vault>(query, new { id });
    }

    public Vault GetById(int id)
    {
      string query = "SELECT * FROM vaults WHERE id = @id";
      Vault Vault = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (Vault == null) throw new Exception("Invalid Id");
      return Vault;
    }
    // public IEnumerable<Note> GetKeepsByVaultId(int id)
    // {
    //   string query = @"
    //         SELECT * FROM noteVaults fb
    //         INNER JOIN notes f ON f.id = fb.noteId
    //         WHERE VaultId = @id
    //         ";
    //   return _db.Query<Note>(query, new { id });
    // }

    public Vault Create(Vault value)
    {
      string query = @"
            INSERT INTO vaults (name, description, userId)
                    VALUES (@Name, @Description, @UserId);
                    SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public string AddKeepToVault(VaultKeep vk)
    {
      string query = @"INSERT INTO vaultkeeps (vaultId, keepId)
                                    VALUES (@VaultId, @KeepId);";
      int changedRows = _db.Execute(query, vk);
      if (changedRows < 1) throw new Exception("Invalid Ids");
      return "Successfully added Keep to Vault";
    }



    public Vault Update(Vault value)
    {
      string query = @"
            UPDATE Vaults
            SET
                name = @Name,
                description = @Description,
                img = @Img
            WHERE id = @Id;            
            SELECT * FROM Vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM Vaults WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Vault";

    }

  }
}