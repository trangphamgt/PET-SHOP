import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostComponent } from './components/post/post.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProductComponent } from './components/product/product.component';
import { ProductCategoryComponent } from './components/product-category/product-category.component';
import { BlogCategoryComponent } from './components/blog-category/blog-category.component';
import { UserComponent } from './components/user/user.component';


const routes: Routes = [
  {
    path: "admin",
    children: [
      {
        path: "menu",
        component : MenuComponent
      },
      {
        path : "product",
        component: ProductComponent
      },
      {
        path: "product-category",
        component: ProductCategoryComponent
      },
      {
        path: "blog-category",
        component: BlogCategoryComponent
      },
      {
        path: "user",
        component: UserComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
