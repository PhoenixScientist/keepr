<template>
  <div>
    <div v-for="keep in keeps" :key="keep.id" class="card">
      <img class="card-img-top mt-2" :src="keep.img">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        {{keep.id}}{{keep.isPrivate}}
        <p class="card-title">{{keep.description}}</p>
        <button class="btn" @click="increment()"><i class="fas fa-eye"></i>{{keep.views}}</button>
        <button class="btn" @click="increment()"><i class="fas fa-share"></i>{{keep.shares}}</button>
        <button class="btn" @click="increment()"><i class="fas fa-dungeon"></i>{{keep.keeps}}</button>
        <button v-if="keep.userId==user.id "><i class="far fa-trash-alt" @click="removeKeep(keep.id)"></i></button>
        <button v-if="keep.userId==user.id || keep.isPrivate"><i class="fas fa-user-shield"></i></button>
        <!-- -->
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" role="button" id="dropdownMenuLink" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Store in Vault
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <button class="dropdown-item" v-for="vault in vaults" type="submit" :key="vault.id"
              @click="makeVaultKeep(keep.id, vault.id)">{{vault.name}}{{vault.id}}</button>
          </div>
          </form>
        </div>
      </div>
    </div>
  </div>
  </div>

  </div>
</template>

<script>
  export default {
    name: 'KeepsCard',

    data() {
      return {
        vaultKeep: {
          vaultId: "",
          keepId: ""
        } // END vaultKeep
      };
    }, // END data
    mounted() {
      this.$store.dispatch('getVaults')
      // this.$store.dispatch('getVaults')
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      user() {
        return this.$store.state.user;
      },
    }, //END Computed

    methods: {
      selectedKeep(id) {
        return this.$store.dispatch("setKeeps", id)
      },
      makeVaultKeep(keep, vault) {

        let data = {
          VaultId: vault,
          KeepId: keep
        }
        this.$store.dispatch("makeVaultKeep", data);
      }, //END makeVaultKeeps
      removeKeep(id) {

        this.$store.dispatch('removeKeep', id)
      },
    } //END methods

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>