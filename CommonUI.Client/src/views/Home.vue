<template>
  <div id="welcome">
    <el-row>
      <el-col :span="24">
        <h1>Welcome to Common UI</h1>
      </el-col>
      <el-col :span="24">Please select your target port</el-col>
      <el-col :span="24">
        <el-select placeholder="Ports" v-model="selectedPort" @change="redirect">
          <el-option v-for="port in ports" :key="port" :label="port" :value="port"></el-option>
        </el-select>
      </el-col>
    </el-row>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  // data
  ports: string[] = ['NIN', 'SHA', 'ZIN', 'ZIA'];
  selectedPort: string = '';

  // method
  redirect(port: string) {
    this.$router.push(`/port/${port}`);
  }
}
</script>


<style scoped>
#welcome {
  display: block;
  text-align: center;
}
</style>

