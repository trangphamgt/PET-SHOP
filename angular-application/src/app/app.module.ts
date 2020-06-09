import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { MatTableModule } from "@angular/material/table";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { UserComponent } from "./components/user/user.component";
import { MenuComponent } from "./components/menu/menu.component";
import { ProductComponent } from "./components/product/product.component";
import { OrderComponent } from "./components/order/order.component";
import { UserRoleComponent } from "./components/user-role/user-role.component";
import { PostComponent } from "./components/post/post.component";
import { DashboardHeaderComponent } from "./components/dashboard-header/dashboard-header.component";
import { LeftSidebarComponent } from "./components/left-sidebar/left-sidebar.component";
import { ProductCategoryComponent } from "./components/product-category/product-category.component";
import { BlogCategoryComponent } from "./components/blog-category/blog-category.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent } from './components/footer/footer.component';

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
    DashboardHeaderComponent,
    LeftSidebarComponent,
    ProductCategoryComponent,
    BlogCategoryComponent,
    FooterComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, MatTableModule, BrowserAnimationsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
