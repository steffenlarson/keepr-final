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
            <div class="col-6">
              <img class="img-fluid my-3" :src="keepProp.img" alt="">
            </div>
            <div class="col-6">
              <h2>{{ keepProp.name }}</h2>
              <p>{{ keepProp.description }} </p>
              <router-link class="text-dark link" :to="{name: 'Profile', params: {id: keepProp.id}}" data-dismiss="modal">
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
import { reactive } from 'vue'
// import { AppState } from '../AppState'
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
