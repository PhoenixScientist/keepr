<template>
  <div>
    <div v-for="vault in vaults" :key="vault.id" class="card">
      <img class="card-img-top mt-2" :src="vault.img">
      <div class="card-body">
        <h5 class="card-title">{{vault.name}}</h5>
        <p class="card-title">{{vault.description}}</p>
        <router-link :to="{name: 'VaultKeeps', params: {vaultId:vault.id}}"><button class="btn"><i
              class="fas fa-hands"></i>{{vault.views}}</button>
        </router-link> <i class="far fa-trash-alt" @click="removeVault(vault.id)"></i>
        <!-- v-if="!vault.isPrivate" -->
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'VaultsCard',

    data() {
      return {};
    },

    computed: {
      vaults() {
        return this.$store.state.vaults;
      },
    },

    methods: {
      selectedVault(id) {
        return this.$store.dispatch("setVaults", id)
      },
      removeVault(id) {

        this.$store.dispatch('removeVault', id)
      },
    }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>