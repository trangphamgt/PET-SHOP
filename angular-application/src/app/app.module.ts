import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from  '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserComponent } from './components/user/user.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProductComponent } from './components/product/product.component';
import { OrderComponent } from './components/order/order.component';
import { UserRoleComponent } from './components/user-role/user-role.component';
import { PostComponent } from './components/post/post.component';
import { LifecycleHookComponent } from './lifecycle-hook/lifecycle-hook.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    UserComponent,
    MenuComponent,
    ProductComponent,
    OrderComponent,
    UserRoleComponent,
    PostComponent,
    LifecycleHookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
