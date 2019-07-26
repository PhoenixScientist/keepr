<template>
  <div class="card">
    <h3><i class="fas fa-hands"></i></h3>
    <form @submit.prevent="makeKeep" class="keepForm">
      <input type="text" class="name" id="name" value="name" v-model="KeepMake.name" placeholder="Name">
      <input type="text" class="" id="description" value="description" v-model="KeepMake.description"
        placeholder="description">
      <input type="url" class="" id="img" value="img" v-model="KeepMake.img" placeholder="Img Url">
      <button class="btn btn-primary" type="submit">Create</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'KeepMaker',

    data() {
      return {
        KeepMake: {
          name: "",
          description: "",
          img: ""
        }
      };
    },

    computed: {
      keeps() {
        return this.$store.state.keeps;
      },
    },

    methods: {
      selectedKeep(id) {
        return this.$store.dispatch("setKeeps", id)
      },
      makeKeep() {

        this.$store.dispatch('makeKeep', this.KeepMake)
      }
    }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>