using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

    public Keep GetById(int id)
    {
      string query = "SELECT * FROM keeps WHERE id = @id";
      Keep keep = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (keep == null) throw new Exception("Invalid Id");
      return keep;
    }
    public IEnumerable<Keep> GetKeepsByUserId(string id)
    {
      string query = @"
            SELECT * FROM keeps
            WHERE userId = @id
            ";
      return _db.Query<Keep>(query, new { id });
    }

    public Keep Create(Keep value)
    {
      string query = @"
            INSERT INTO keeps (img, name, description, isPrivate, userId)
                    VALUES (@Img, @Name, @Description, @IsPrivate, @UserId);
                    SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      // string userId = this._db.username;
      return value;
    }

    // public string AddNoteToKeep(NoteKeep fb)
    // {
    //   string query = @"INSERT INTO notekeeps (keepId, noteId, boardId)
    //                                 VALUES (@KeepId, @NoteId, @BoardId);";
    //   int changedRows = _db.Execute(query, fb);
    //   if (changedRows < 1) throw new Exception("Invalid Ids");
    //   return "Successfully added Note to Keep";
    // }



    public Keep Update(Keep value)
    {
      string query = @"
            UPDATE keeps
            SET
                name = @Name,
                description = @Description,
                img = @Img,
                isPrivate = @IsPrivate
            WHERE id = @Id;            
            SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM keeps WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Keep";

    }

  }
}