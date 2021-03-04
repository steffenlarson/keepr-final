<template>
  <div class="ProfilePage container-fluid">
    <div class="row">
      <div class="col">
        <p>This is the profile page</p>
        <div class="about">
          <!-- <h1>Welcome {{ AppState.activeProfile.name }}</h1> -->
          <!-- <img class="rounded" :src="AppState.activeProfile.picture" alt="" /> -->
          <p>Count</p>
          <p>count 2</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h3>Vaults</h3>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h3>Keeps</h3>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { route } from 'vue-router'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { profilesService } from '../services/ProfilesService'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'ProfilePage',
  setup() {
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile)
    })
    onMounted(async() => {
      try {
        await profilesService.getProfileById(route.params.id)
        await vaultsService.getVaultsByProfileId(route.params.id)
        await keepsService.getKeepsByProfileId(route.params.id)
      } catch (error) {

      }
    })
    return {
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
