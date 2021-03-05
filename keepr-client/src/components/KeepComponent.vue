<template>
  <div class="KeepComponent col-md-4 col-6 mt-2">
    <div class="card">
      <img class="img-fluid" :src="keepProp.img" alt="">
      <div class="card-body position">
        <div class="row">
          <div class="col">
            <h4 class="card-title ">
              {{ keepProp.name }}
            </h4>
          </div>
          <div class="col">
            <h4>
              <i class="fa fa-user" aria-hidden="true"></i>
            </h4>
          </div>
        </div>
      </div>
    </div>
    <div class="row MyModal ">
      <div class="modal fade bd-example-modal-lg"
           tabindex="-1"
           role="dialog"
           id="keepDetails"
           aria-labelledby="myLargeModalLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-lg container-fluid">
          <div class="row modal-content">
            <div class="col-6">
              <img class="img-fluid my-3" :src="keepProp.img" alt="">
            </div>
            <div class="col-6">
              <h2>{{ keepProp.name }}</h2>
              <p>{{ keepProp.description }} </p>
              <!-- TODO keep count and view count -->

              <span>
                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle"
                          type="button"
                          id="dropdownMenuButton"
                          data-toggle="dropdown"
                          aria-haspopup="true"
                          aria-expanded="false"
                  >
                    Move
                  </button>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <button class="dropdown-item"
                            :id="vault.id"
                            v-for="vault in state.vaults "
                            :key="vault.id"
                            @click="addToVault(vault.id)"
                            href="#"
                    > {{ vault.title }}</button>
                    <div>
                      <!-- TODO delete keep vif creator id == user id -->
                    </div>
                  </div>
                </div>
              </span>

              <router-link class="text-dark link" :to="{name: 'Profile', params: {id: keepProp.creatorId}}" data-dismiss="modal">
                <i class="fa fa-user" aria-hidden="true"></i>
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
// import { vaultsService } from '../services/VaultsService'
// import { logger } from '../utils/Logger'
// import { AppState } from '../AppState'
export default {
  name: 'KeepComponent',
  props: { keepProp: { type: Object, required: true } },
  setup(props) {
    const state = reactive({
      vaults: computed(() => AppState.vaults)
    })
    return {
      state
      // async addToVault(id) {
      //   try {
      //     // REVIEW help here I am not sure which service this needs to go to.
      //     await vaultsService.addTo
      //   } catch (error) {
      //     logger.error(error)
      //   }
      // }

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.position{
  position: absolute;
  bottom: 0;
  transform: translateY(25%)
}
</style>
