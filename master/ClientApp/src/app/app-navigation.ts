export const navigation = [
  {
    text: '机构与权限',
    //path: '/admin/rbac',
    icon: 'home',
    items: [
      { text: "组织管理", path: "/admin/rbac/org" },
      { text: "菜单管理", path: "/admin/rbac/menu" },
      { text: "角色管理", path: "/admin/rbac/role" },
      { text: "用户管理", path: "/admin/rbac/user" }
    ]
  },
  
  {
    text: '产品管理',
    icon: 'folder',
    items: [
      {
        text: '产品',
        path: '/admin/product/product'
      },
      {
        text: '产品标签',
        path: '/admin/product/product-tag'
      },
      {text:"广告管理",path:"/admin/product/banner"}

    ]
  },
  {
    text: "广告管理",
    icon:"home",
    items:[]
  }
];
