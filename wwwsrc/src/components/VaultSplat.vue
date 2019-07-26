<template>
  <div class="container-fluid">
    <!-- Vault -->
    <div class="row">
      <div class="col">
        <h1>Vaults</h1>
      </div>
    </div>

    <div class="row">
      <div class="col">
        <VaultMaker />

        <VaultsCard />

      </div>
    </div>

  </div>

</template>

<script>
  import VaultMaker from '@/components/VaultMaker.vue'
  import VaultsCard from '@/components/VaultsCard.vue'
  export default {
    name: 'VaultSplat',
    components: {
      VaultMaker,
      VaultsCard
    },
    mounted() {
      this.$store.dispatch('getVaults')
    },
    data() {
      return {};
    },
    computed: {
      Vaults() {
        return this.$store.state.Vaults;
      },
    },

    methods: {
      // selectedVault(id) {
      // return this.$store.dispatch("setVaults", id)
      // }
    }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  td {
    color: red;
  }

  th {
    height: 0%;
    width: 0;
  }

  .no {
    height: 1px;
    color: #ffffff00;
  }

  .tcol {
    width: 100px;
  }

  .scol {
    width: 500px;
  }

  .closed {
    background-color: #b8864970;
    font-style: italic;
  }

  .card {
    min-width: 200px;
    width: 30vw;
    padding: 1%;
    background-color: blue;
  }
</style>