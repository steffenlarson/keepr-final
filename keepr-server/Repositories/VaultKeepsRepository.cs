using System.Data;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
  public class VaultKeepsRepository
  {


    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    // FIXME The lines 27-29  need to increment keeps value on create
    internal int Create(VaultKeep vk)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (creatorId, vaultId, keepId)
      VALUES
      (@CreatorId, @VaultId, @KeepId);
      UPDATE keeps
      SET Keeps = Keeps + 1
      WHERE keep.id = @keepId;
      SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, vk);
    }
    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }



  }
}