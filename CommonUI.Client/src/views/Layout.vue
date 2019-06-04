<template>
  <el-container id="layout">
    <!-- left menu -->
    <MenuBar :isCollapse="isMenuCollapse"/>
    <!-- main  -->
    <el-container>
      <el-header class="header-line">
        <!-- menu toggle button -->
        <span @click="toggleMenu" id="menu-icon">
          <i :class="[isMenuCollapse ? 'el-icon-ant-indent' :  'el-icon-ant-outdent']"></i>
        </span>
      </el-header>
      <el-main>
        <router-view/>
      </el-main>
    </el-container>
  </el-container>
</template>

<script lang="ts">
import MenuBar from '../components/MenuBar.vue';
import { Component, Prop, Vue } from 'vue-property-decorator';

// import component
@Component({
  components: {
    MenuBar
  }
})
export default class Layout extends Vue {
  // data
  isMenuCollapse: boolean = false;

  // method
  toggleMenu() {
    this.isMenuCollapse = !this.isMenuCollapse;
  }
}
</script>

<style>
#layout {
  background: #2c3e50;
  height: 100%;
  width: 100%;
}

.header-line {
  background: #409eff;
  line-height: 60px;
  color: antiquewhite;
}

.header-line i {
  line-height: 60px;
  font-size: 25px;
}

#menu-icon {
  cursor: pointer;
}
</style>
