using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
  public class KeepsRepository
  {

    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep 
       JOIN profiles profile ON keep.creatorId = profile.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    internal Keep Get(int id)
    {
      string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep 
       JOIN profiles profile ON keep.creatorId = profile.id
       WHERE keep.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id").FirstOrDefault();
    }


    internal int Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO Keeps
            (name, creatorId, description, img)
            VALUES
            (@Name, @CreatorId, @Description, @Img);
            SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, KeepData);
    }

    internal Keep Edit(Keep editData)
    {
      string sql = @"
            UPDATE keeps
            SET 
            name = @Name,
            description = @Description,
            img = @Img
            WHERE id = @Id;";
      _db.Execute(sql, editData);
      return editData;
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }



    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT k.*,
      vk.id as VaultKeepId 
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      WHERE vaultId = @vaultId";

      return _db.Query<VaultKeepViewModel>(sql, new { vaultId });
    }






    internal IEnumerable<Keep> GetByCreatorId(string id)
    {
      string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep 
       JOIN profiles profile ON keep.creatorId = profile.id
       WHERE keep.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id");

    }


  }
}