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

    internal void Create(VaultKeep vk, string id)
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
      _repo.Create(vk);
    }

    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }





  }
}