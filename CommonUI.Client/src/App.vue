<template>
  <div id="app" style="height:100vh">
    <router-view />
  </div>
</template>

<script lang="ts">
import { Vue } from 'vue-property-decorator';

export default class App extends Vue { }
</script>

<style>
html body {
  font-family: Helvetica, Arial, sans-serif;
}
</style>
