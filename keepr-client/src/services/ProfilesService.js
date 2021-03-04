import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfilesService {
  async getProfileById(id) {
    // REVIEW this debugger never gets hit
    // debugger
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
    logger.log('this is the profile', res.data)
  }
}

export const profilesService = new ProfilesService()
