<template>
  <div class="home container-fluid">
    <div class="row">
      <keep-component v-for="k in state.keeps"
                      :key="k.id"
                      :keep-prop="k"
      />
    </div>
  </div>
</template>

<script>
import { reactive, onMounted, computed } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import $ from 'jquery'
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
          state.activeKeep = {}
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
