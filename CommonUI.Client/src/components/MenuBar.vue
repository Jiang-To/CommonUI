<template>
  <div>
    <el-menu :collapse="isCollapse" id="menu">
      <template v-for="item in menu">
        <!-- render menu item -->
        <el-menu-item :index="item.index" v-if="!item.subMenu" :key="item.index" @click="redirect(item)">
          <i :class="item.icon"></i>
          <span slot="title">{{item.title}}</span>
        </el-menu-item>

        <!-- render group menu item -->
        <el-submenu :index="item.index" v-if="item.subMenu" :key="item.index">
          <template slot="title">
            <i :class="item.icon"></i>
            <span slot="title">{{item.title}}</span>
          </template>
          <el-menu-item
            v-for="subItem in item.subMenu"
            :key="subItem.index"
            :index="subItem.index"
            @click="redirect(subItem)"
          >{{subItem.title}}</el-menu-item>
        </el-submenu>
      </template>
    </el-menu>

    <!-- official example -->
    <!-- <el-menu :collapse="isCollapse" id="menu">
      <el-menu-item index="1">
        <i class="el-icon-ant-home"></i>
        <span slot="title">Home</span>
      </el-menu-item>
      <el-submenu index="2">
        <template slot="title">
          <i class="el-icon-ant-Import"></i>
          <span slot="title">Extraction</span>
        </template>
        <el-menu-item index="2-1">Initial Extraction</el-menu-item>
        <el-menu-item index="2-2">Extraction Status</el-menu-item>
      </el-submenu>
    </el-menu>-->
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import router from '../router';

export interface MenuItem {
  index: string;
  title: string;
  route: string;
  icon?: string;
}

export interface MenuGroupItem {
  index: string;
  title: string;
  icon?: string;
  subMenu: MenuItem[];
}

const menuList: Array<MenuItem | MenuGroupItem> = [
  {
    index: '1',
    title: 'Home',
    route: 'home',
    icon: 'el-icon-ant-home'
  },
  {
    index: '2',
    title: 'Extraction',
    icon: 'el-icon-ant-Import',
    subMenu: [
      {
        index: '2-1',
        title: 'Initial Extraction',
        route: 'initial extraction'
      },
      {
        index: '2-2',
        title: 'Extraction Status',
        route: 'extraction status'
      }
    ]
  }
];

@Component
export default class MenuBar extends Vue {
  // props
  @Prop({ default: true })
  isCollapse!: boolean;

  // data
  menu: Array<MenuItem | MenuGroupItem> = menuList;

  // method
  redirect(item: MenuItem) {
    this.$router.push({name: item.route});
  }
}
</script>


<style scoped>
.header-line {
  background: #409eff;
  line-height: 60px;
  color: antiquewhite;
  display: block;
  text-align: center;
}

#menu {
  min-height: 100vh;
}

#menu:not(.el-menu--collapse) {
  width: 200px;
}
</style>

