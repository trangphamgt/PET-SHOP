import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { MenugroupsComponent } from './menugroups/menugroups.component';
import { MenugroupComponent } from './menugroups/menugroup/menugroup.component';
import { MenugroupListComponent } from './menugroups/menugroup-list/menugroup-list.component';
import { MenugroupsService } from './shared/menugroups.service';
import {HttpClientModule} from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    MenugroupsComponent,
    MenugroupComponent,
    MenugroupListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [MenugroupsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
