import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { DashboardComponent} from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './user-area/home/home.component';
import {HttpClientModule} from '@angular/common/http';
import { MenuService } from './shared/menu/menu.service';
import { PostService } from './shared/post/post.service';
import { ProductService } from './shared/product/product.service';
import { UserService } from './shared/user/user.service';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [
    MenuService,
    PostService,
    ProductService,
    MenuService,
    UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
