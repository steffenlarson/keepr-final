import { AppState } from '../AppState'
// import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    // logger.log('a keep', res)
    AppState.keeps = res.data
  }

  async getOne(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
    // logger.log(res.data)
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.keeps = res.data
  }

  async getKeepsByAccount() {
    const res = await api.get('api/account/keeps')
    AppState.keeps = res.data
  }

  async createKeep(keep) {
    const res = await api.post('api/keeps/', keep)
    AppState.keeps.push(res.data)
    return res.data.id
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    return 'successfully Deleted'
  }
}

export const keepsService = new KeepsService()
