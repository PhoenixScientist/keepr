<template>
  <div class="home">
    <h3>Welcome Home {{user.username}}</h3>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <KeepSplat />
  </div>
</template>

<script>
  import KeepSplat from '@/components/KeepSplat.vue'
  export default {
    name: "home",
    components: {
      KeepSplat
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