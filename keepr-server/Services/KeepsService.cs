


using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
  public class KeepsService
  {

    private readonly KeepsRepository _repo;
    private readonly VaultsRepository _vrepo;
    public KeepsService(KeepsRepository repo, VaultsRepository vrepo)
    {
      _repo = repo;
      _vrepo = vrepo;
    }


    public IEnumerable<Keep> GetAll()
    {
      IEnumerable<Keep> restaurants = _repo.GetAll();
      return restaurants;
    }

    internal Keep Get(int id)
    {
      var data = _repo.Get(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }


    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal Keep Edit(Keep editData, string userId)
    {
      Keep original = Get(editData.Id);
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Keep You did not Create"); }
      editData.Name = editData.Name == null ? original.Name : editData.Name;
      editData.Description = editData.Description == null ? original.Description : editData.Description;
      editData.Img = editData.Img == null ? original.Img : editData.Img;

      return _repo.Edit(editData);

    }

    internal string Delete(int id, string userId)
    {
      Keep original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Keep You did not Create"); }
      _repo.Remove(id);
      return "successfully deleted";
    }



    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      Vault exists = _vrepo.Get(vaultId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetKeepsByVaultId(vaultId);
    }





    internal IEnumerable<Keep> GetByProfileId(string id)
    {
      return _repo.GetByCreatorId(id);
    }


  }
}