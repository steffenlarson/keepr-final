<template>
  <div class="ProfilePage container-fluid">
    <div class="row">
      <div class="col">
        <div class="about">
          <h1>{{ state.activeProfile.name }}</h1>
          <img class="rounded" :src="state.activeProfile.picture" alt="" />
        </div>
        <div class="col">
          <p>Count</p>
          <p>count 2</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h3>
          Vaults         <button
            data-toggle="modal"
            data-target="#vaultCreator"
          >
            +
          </button>
        </h3>

        <vault-component v-for="v in state.vaults" :key="v.id" :vault-prop="v" />
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h3>
          Keeps         <button
            data-toggle="modal"
            data-target="#keepCreator"
          >
            +
          </button>
        </h3>

        <keep-component v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
      </div>
    </div>
    <div class="Modals">
      <div class="Vault Modal">
        <div class="modal fade"
             id="vaultCreator"
             tabindex="-1"
             role="dialog"
             aria-labelledby="vaultCreatorLabel"
             aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="vaultCreatorLabel">
                  New Vault
                </h5>
                <form type="submit" @submit.prevent="createVault">
                  <div class="form-group text-center">
                    <label for=""></label>

                    <input type="text"
                           class="form-control"
                           name="newVault"
                           v-model="state.newVault.name"
                           id="name"
                           aria-describedby="helpId"
                           placeholder="Vault name"
                    >

                    <input type="text"
                           class="form-control"
                           name="newVault"
                           v-model="state.newVault.description"
                           id="board"
                           aria-describedby="helpId"
                           placeholder="Vaults Description"
                    >
                    <input type="checkbox" v-model="state.newVault.isPrivate">
                    <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Close
                      </button>
                      <button type="submit" class="btn btn-outline btn-success ">
                        Submit
                      </button>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="Keep Modal">
        <div class="modal fade"
             id="keepCreator"
             tabindex="-1"
             role="dialog"
             aria-labelledby="keepCreatorLabel"
             aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="keepCreatorLabel">
                  New Keep
                </h5>
                <form type="submit" @submit.prevent="createKeep">
                  <div class="form-group text-center">
                    <label for=""></label>

                    <input type="text"
                           class="form-control"
                           name="newKeep"
                           v-model="state.newKeep.name"
                           id="name"
                           aria-describedby="helpId"
                           placeholder="Keep name"
                    >
                    <input type="text"
                           class="form-control"
                           name="newKeep"
                           v-model="state.newKeep.img"
                           id="board"
                           aria-describedby="helpId"
                           placeholder="Img url"
                    >

                    <input type="text"
                           class="form-control"
                           name="newKeep"
                           v-model="state.newKeep.description"
                           id="board"
                           aria-describedby="helpId"
                           placeholder="Keep Description"
                    >
                    <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Close
                      </button>
                      <button type="submit" class="btn btn-outline btn-success ">
                        Submit
                      </button>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { profilesService } from '../services/ProfilesService'
import { keepsService } from '../services/KeepsService'
export default {

  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      newVault: {},
      newKeep: {},
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)

    })
    onMounted(async() => {
      try {
        await profilesService.getProfileById(route.params.id)
        await vaultsService.getVaultsByProfileId(route.params.id)
        await keepsService.getKeepsByProfileId(route.params.id)
      } catch (error) {
        logger.error(error)
      }
    })
    return {
      state,
      createVault() {
        state.newVault.creatorId = route.params.id
        vaultsService.createVault(state.newVault)
        state.newVault = {}
      },
      createKeep() {
        state.newKeep.creatorId = route.params.id
        keepsService.createKeep(state.newKeep)
        state.newKeep = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
