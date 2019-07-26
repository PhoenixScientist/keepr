<template>
  <div id="app">
    <div id="nav">
      <router-link to="/"><i class="fas fa-hands"></i></router-link>
      <router-link to="/vaults"><i class="fas fa-dungeon"></i></router-link>
    </div>
    <router-view />
  </div>
</template>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .card {
    min-width: 200px;
    width: 30vw;
    padding: 1%;
    background-color: blue;
    color: cornsilk;
  }
</style>