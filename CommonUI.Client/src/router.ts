import Vue from 'vue';
import Router, { RouteConfig } from 'vue-router';

import Home from './views/Home.vue';

Vue.use(Router);

const pageRouter: RouteConfig[] = [
  {
    path: 'extraction/new',
    name: 'initial extraction',
    // route level code-splitting
    // this generates a separate chunk (extraction.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import( /* webpackChunkName: "extraction" */ './views/Extraction/InitialExtraction.vue'),
  },
  {
    path: 'extractions',
    name: 'extraction status',
    component: () => import( /* webpackChunkName: "extraction" */ './views/Extraction/ExtractionStatus.vue'),
  },
];

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
     {
      path: '/port/:port',
      name: 'port',
      component: () => import( /* webpackChunkName: "layout" */ './views/Layout.vue'),
      children: [
        ...pageRouter,
      ]
    },
    {
      path: '*',
      component: () => import( /* webpackChunkName: "404" */ './views/NotFound.vue'),
    }
  ],
});
