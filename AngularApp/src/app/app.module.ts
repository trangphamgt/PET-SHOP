import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PostsComponent } from './posts/posts.component';
import { PostComponent } from './posts/post/post.component';
import { PostListComponent } from './posts/post-list/post-list.component';
import { PostService } from './shared/post.service';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from '@angular/common/http';
import { MenugroupsComponent } from './menugroups/menugroups.component';
import { MenugroupComponent } from './menugroups/menugroup/menugroup.component';
import { MenugroupListComponent } from './menugroups/menugroup-list/menugroup-list.component';
import { MenuGroupService } from './shared/menu-group.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    PostsComponent,
    PostComponent,
    PostListComponent,
    MenugroupsComponent,
    MenugroupComponent,
    MenugroupListComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [PostService,
    MenuGroupService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
