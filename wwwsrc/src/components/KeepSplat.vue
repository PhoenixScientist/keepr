<template>
  <div class="container-fluid">
    <!-- Keep -->
    <div class="row">
      <div class="col">
        <h1>
          <button @click="AllKeeps">All Keeps</button> | <button @click="getKeepsByUser">My Keeps</button>
        </h1>
      </div>
    </div>

    <div class="row">
      <div class="col">
        <KeepMaker />

        <KeepsCard />

      </div>
    </div>

  </div>

</template>

<script>
  import KeepMaker from '@/components/KeepMaker.vue'
  import KeepsCard from '@/components/KeepsCard.vue'
  export default {
    name: 'KeepSplat',
    components: {
      KeepMaker,
      KeepsCard
    },
    mounted() {
      this.$store.dispatch('getKeeps')
    },
    data() {
      return {};
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      },
    },

    methods: {
      AllKeeps() {
        return this.$store.dispatch("getKeeps")
      },
      getKeepsByUser() {
        return this.$store.dispatch("getKeepsByUser")
      },
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