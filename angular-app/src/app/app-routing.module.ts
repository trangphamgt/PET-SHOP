import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenusComponent } from './dashboard/menus/menus.component';
import { OrdersComponent } from './dashboard/orders/orders.component';
import { PostsComponent } from './dashboard/posts/posts.component';
import { UsersComponent } from './dashboard/users/users.component';
import { ProductsComponent } from './dashboard/products/products.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  {path:"admin", component: DashboardComponent},
  {path:"admin/menus", component:MenusComponent},
  {path:"admin/orders", component: OrdersComponent},
  {path:"admin/posts", component: PostsComponent},
  {path:"admin/user", component: UsersComponent},
  {path:"admin/products", component: ProductsComponent},
  {path:"**", component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  declarations:[
    MenusComponent,
    OrdersComponent,
    PostsComponent,
    UsersComponent,
    ProductsComponent,
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
