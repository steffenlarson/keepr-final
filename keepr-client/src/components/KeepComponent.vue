<template>
  <div class="KeepComponent col-md-4 col-6">
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
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: { keepProp: { type: Object, required: true } },
  setup(props) {
    const state = reactive({

    })
    return {
      state
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
