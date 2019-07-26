import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultkeeps: []
  }, //END state
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setVaultKeeps(state, data) {
      state.vaultkeeps = data
    },
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async makeKeep({ commit, dispatch, state }, payload) {
      try {
        let res = await api.post('keeps', payload)
        console.log(res.data)
        // dispatch('getKeeps') 
      } catch (error) { console.log(error) }
    }, //END makeKeep
    setKeeps({ commit, dispatch }, data) {
      commit("setKeeps", data)
    }, //END setKeeps
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/')
        console.log("Keeps", res.data)
        commit('setKeeps', res.data)
        console.log("Keeps-", this.state)
      } catch (error) { console.log(error) }
    }, //END getKeeps
    async getKeepsByUser({ commit, dispatch }) {
      try {

        let res = await api.get('keeps/user')
        console.log(this.state.user)
        commit('setKeeps', res.data)
        console.log("Keeps-", this.state)
      } catch (error) { console.log(error) }
    }, //END getKeeps
    async removeKeep({ commit, dispatch, state }, id) {
      try {
        let res = await api.delete('keeps/' + id)
        console.log(res.data)
        dispatch('getKeeps')
      } catch (error) { console.log(error) }
    }, //END removeKeep
    setVaults({ commit, dispatch }, data) {
      commit("setVaults", data)
    }, //END setVaults
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults/')
        console.log("Vaults", res.data)
        commit('setVaults', res.data)
        console.log("Vaults-", this.state)
      } catch (error) { console.log(error) }
    }, //END getVaults
    async makeVault({ commit, dispatch, state }, payload) {
      try {
        let res = await api.post('vaults', payload)
        console.log(res.data)
        // dispatch('getVaults') 
      } catch (error) { console.log(error) }
    }, //END makeVault
    async removeVault({ commit, dispatch, state }, id) {
      try {
        let res = await api.delete('vaults/' + id)
        console.log(res.data)
        dispatch('getVaults')
      } catch (error) { console.log(error) }
    }, //END removeVault
    async getKeepsByVaultId({ commit, dispatch }, VaultId) {
      try {

        let res = await api.get('vaultkeeps/' + VaultId)
        commit('setVaultKeeps', res.data)
        // console.log("Vaults-", this.state)
      } catch (error) { console.log(error) }
    }, //END getKeepsByVaultId
    async makeVaultKeep({ commit, dispatch }, vaultkeep) {
      try {

        let res = await api.put('vaultkeeps', vaultkeep)
        // commit('setVaultKeeps', res.data)
        // console.log("Vaults-", this.state)
      } catch (error) { console.log(error) }
    }, //END getKeepsByVaultId
    async removeKeepFromVault({ commit, dispatch }, data) {
      try {
        let res = await api.put('vaultkeeps', data)
        dispatch('getVaultKeeps', data.VaultId)
        // console.log("Vaults-", this.state)
      } catch (error) { console.log(error) }
    }, //END getKeepsByVaultId
  }
})
