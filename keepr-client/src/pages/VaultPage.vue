<template>
  <div class="VaultPage">
    <!-- TODO add delete vault vif the vault creator id == account id or user id (Person logged in) -->

    <p>This is the vault page</p>
    <p>{{ state.activeVault.name }}</p>
    <p>{{ state.activeVault.description }} </p>
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
      activeVault: computed(() => AppState.activeVault)
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
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
