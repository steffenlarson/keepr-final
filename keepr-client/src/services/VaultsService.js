import { AppState } from '../AppState'
import { api } from './AxiosService'
import { logger } from '../utils/Logger'

class VaultsService {
  async getVaults() {
    const res = await api.get('api/vaults')
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
    logger.log('this is the vault', res.data)
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }

  async getVaultsByAccount() {
    const res = await api.get('api/account/vaults')
    AppState.myVaults = res.data
  }

  async getKeepsByVaultId(id) {
    // REVEIW I think that the route for this is wrong.
    const res = await api.get('api/vaults/' + id + '/keeps')
    AppState.keeps = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaults/', vault)
    AppState.vaults.push(res.data)
    return res.data.id
  }

  async deleteVault(id) {
    // debugger
    if (confirm('Are you sure?') === true) {
      await api.delete('api/vaults/' + id)
      this.getVaultsByAccount()
    }
  }

  async addToVault(vaultKeep) {
    const res = await api.post('api/')
  }
}

export const vaultsService = new VaultsService()
