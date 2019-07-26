<template>
  <div class="home">
    <h3>Welcome Home {{user.username}}</h3>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>

    <VaultSplat />
  </div>
</template>

<script>
  import VaultSplat from '@/components/VaultSplat.vue'
  export default {
    name: "Vaults",
    components: {
      VaultSplat
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>