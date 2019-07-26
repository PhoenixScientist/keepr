<template>
  <div class="card">
    <h3><i class="fas fa-dungeon"></i></h3>
    <form @submit.prevent="makeVault" class="vaultForm">
      <input type="text" class="name" id="name" value="name" v-model="VaultMake.name" placeholder="Name">
      <input type="text" class="" id="description" value="description" v-model="VaultMake.description"
        placeholder="description">
      <!-- <input type="url" class="" id="img" value="img" v-model="VaultMake.img" placeholder="Img Url"> -->
      <button class="btn btn-primary" type="submit">Create</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'VaultMaker',

    data() {
      return {
        VaultMake: {
          name: "",
          description: ""
          // img: ""
        }
      };
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
      makeVault() {

        this.$store.dispatch('makeVault', this.VaultMake)
      }
    }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>