using System;
using keepr_server.Exceptions;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
  public class VaultKeepsService
  {


    private readonly VaultKeepsRepository _repo;
    private readonly VaultsRepository _vr;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vr)
    {
      _repo = repo;
      _vr = vr;
    }

    internal VaultKeep Create(VaultKeep vk, string id)
    {
      Vault vault = _vr.Get(vk.VaultId);

      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.CreatorId != id)
      {
        throw new Forbidden("Not The Owner of this Vault");
      }
      vk.Id = _repo.Create(vk);
      return vk;
    }

    internal string Delete(int id, string userId)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != userId)
      {
        throw new Exception("Cannot Delete vaults you do not own.");
      }
      _repo.Delete(id);
      return "successfully deleted";
    }





  }
}