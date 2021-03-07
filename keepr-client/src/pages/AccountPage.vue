<template>
  <div>
    <div class="about text-center">
      <h1>Welcome {{ account.name }}</h1>
      <img class="rounded" :src="account.picture" alt="" />
      <p>{{ account.email }}</p>
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
                  <input type="checkbox" v-model="state.newVault.isPrivate" value="false">
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
</template>

<script>
import { computed, reactive, onMounted } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
// import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import $ from 'jquery'
export default {
  name: 'Account',
  setup() {
    // const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      newVault: {},
      newKeep: {},
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user)

    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultsByAccount()
        await keepsService.getKeepsByAccount()
      } catch (error) {
        logger.error(error)
      }
    })
    return {
      state,
      account: computed(() => AppState.account),
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          logger.log(state.newVault)
          $('#vaultCreator').modal('hide')
          state.newVault = {}
        } catch (error) {
          logger.error(error)
        }
        // state.newVault.creatorId = state.account.Id
      },
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          $('#keepCreator').modal('hide')
          state.newKeep = {}
        } catch (error) {
          logger.error(error)
        }
        // state.newKeep.creatorId = state.account.Id
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
