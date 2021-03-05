<template>
  <div class="VaultComponent container-fluid">
    <router-link :to="{name: 'Vault', params: {id: vaultProp.Id}}">
      <div class="card">
        <div class="card-body position">
          <div class="row">
            <div class="col">
              <h4 class="card-title ">
                {{ vaultProp.name }}
              </h4>
            </div>
            <div class="col">
              <h4>
                <i class="fa fa-user" aria-hidden="true"></i>
              </h4>
            </div>
            <div class="col text-danger" v-if="vaultProp.creatorId == state.account.id">
              <h4>
                <i class="fa fa-times" aria-hidden="true" @click.stop="deleteVault"></i>
              </h4>
            </div>
          </div>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
export default {
  name: 'VaultComponent',
  props: { vaultProp: { type: Object, required: true } },
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      async deleteVault() {
        try {
          debugger
          vaultsService.deleteVault(props.vaultProp.id)
        } catch (error) {
          logger.error(error)
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
