


using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;
    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }



    public IEnumerable<Vault> GetAll()
    {
      IEnumerable<Vault> restaurants = _vr.GetAll();
      return restaurants;
    }

    internal Vault Get(int id)
    {
      var data = _vr.Get(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }


    public Vault Create(Vault newVault)
    {
      newVault.Id = _vr.Create(newVault);
      return newVault;
    }


    // REVIEW Do I need to add the bool value for the edit. The isPrivate?
    internal Vault Edit(Vault editData, string userId)
    {
      Vault original = Get(editData.Id);

      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault You did not Create"); }
      editData.Name = editData.Name == null ? original.Name : editData.Name;
      editData.Description = editData.Description == null ? original.Description : editData.Description;

      return _vr.Edit(editData);

    }

    internal string Delete(int id, string userId)
    {
      Vault original = _vr.Get(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault You did not Create"); }
      _vr.Remove(id);
      return "successfully deleted";
    }











  }
}