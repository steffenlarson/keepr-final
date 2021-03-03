import { AppState } from '../AppState'
import { api } from './AxiosService'
// import logger from '../utils/Logger'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    // logger.log('a keep', res)
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()
