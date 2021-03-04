<template>
  <div class="VaultComponent container-fluid">
    <div class="card">
      <div class="card-body position">
        <div class="row">
          <div class="col">
            <h4 class="card-title ">
              {{ vaultProp.name }}
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
export default {
  name: 'VaultComponent',
  props: { vaultProp: { type: Object, required: true } },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
