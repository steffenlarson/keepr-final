<template>
  <div class="home container-fluid">
    <div class="row">
      <keep-component v-for="k in state.keeps"
                      :key="k.id"
                      :keep-prop="k"
                      @click="getOne(k.id)"
                      data-toggle="modal"
                      data-target="#keepDetails"
      />
    </div>
    <div class="row MyModal">
      <div class="modal fade bd-example-modal-lg"
           tabindex="-1"
           role="dialog"
           id="keepDetails"
           aria-labelledby="myLargeModalLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-lg">
          <div class="row modal-content">
            <div class="col">
            </div>
            <div class="col">
              <p>Hello</p>
              <p>{{ state.activeKeep.name }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, onMounted, computed } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import { $ } from 'jquery'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep)
    })
    onMounted(async() => {
      try {
        // debugger
        await keepsService.getKeeps()
      } catch (error) {
        logger.error(error)
      }
    })
    return {
      state,
      async getOne(id) {
        try {
          await keepsService.getOne(id)
          $('#keepDetails').modal('hide')
        } catch (error) {
          logger.error(error)
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
