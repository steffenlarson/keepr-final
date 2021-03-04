import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    const res = await api.get('api/vaults')
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaults/', vault)
    AppState.vaults.push(res.data)
    return res.data.id
  }

  async deleteVault(id) {
    await api.delete('api/vaults' + id)
    return 'successfully deleted'
  }
}

export const vaultsService = new VaultsService()
