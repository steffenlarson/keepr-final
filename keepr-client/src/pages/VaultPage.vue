<template>
  <div class="VaultPage container-fluid">
    <div class="row">
      <div class="col">
        <div class="card">
          <h3>Keep Title: {{ state.activeVault.name }}</h3>
          <p>Keep Description: {{ state.activeVault.description }} </p>
          <!-- <p>{{ state.keeps.length }}</p> -->
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col" v-for="k in state.keeps" :key="k.id">
        <i class="fa fa-trash" aria-hidden="true" @click="deleteVaultKeep(k.vaultKeepId)"></i>
        <keep-component :keep-prop="k" />
      </div>
    </div>
    <!-- TODO add delete vault vif the vault creator id == account id or user id (Person logged in) -->
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
// import { keepsService } from '../services/KeepsService'
export default {
  name: 'VaultPage',
  setup(props) {
    const route = useRoute()
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
      // FIXME need to run these functions to set activeVault to appstate.
        await vaultsService.getVaultById(route.params.id)
        // await
        await vaultsService.getKeepsByVaultId(route.params.id)
      } catch (error) {
        logger.error(error)
      }
    })
    // TODO onmounted get vault by id
    // get vault by Id and get vault keeps. get keeps by vault id  vaults/vaultid/keeps
    // vault id will come from route params. See profile for example
    // NOTE need to write functionality for get one vault, get keeps by vault id, delete the keep from the vaultkeep.
    return {
      state,
      async deleteVaultKeep(id) {
        try {
          vaultsService.deleteVaultKeep(id, state.activeVault.id)
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
