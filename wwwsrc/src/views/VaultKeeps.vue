<template>
  <div>
    <h1>ssssssssssssssss</h1>
    <div v-for="keep in vaultkeeps" :key="keep.id" class="card">
      <img class="card-img-top mt-2" :src="keep.img">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-title">{{keep.description}}</p>
        <i class="far fa-trash-alt"></i> <i class="fas fa-minus-circle" @click="removeKeepFromVault(keep.id)"></i>
      </div>
    </div>
  </div>
</template>

<script>
  import VaultsCard from '@/components/VaultsCard.vue'
  export default {
    name: 'VaultKeeps',
    props: ['vaultId'],
    data() {
      return {
      };
    },
    components: {
      VaultsCard
    },
    computed: {
      vaultkeeps() {
        return this.$store.state.vaultkeeps;
      },
    },
    mounted() {

      this.$store.dispatch('getKeepsByVaultId', this.vaultId);
    },

    methods: {
      selectedKeep(id) {
        return this.$store.dispatch("setKeeps", id)
      },
      getKeepsByVaultId() {
        this.$store.dispatch('getKeepsByVaultId', this.vaultId)
      },
      removeKeepFromVault(keepId) {
        let data = {
          VaultId: this.vaultId,
          KeepId: keepId
        };
        this.$store.dispatch('removeKeepFromVault', data)
      }
    }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>