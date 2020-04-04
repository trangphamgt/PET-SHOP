import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { MenugroupsComponent } from './menugroups/menugroups.component';
import { MenugroupComponent } from './menugroups/menugroup/menugroup.component';
import { MenugroupListComponent } from './menugroups/menugroup-list/menugroup-list.component';
import { MenugroupsService } from './shared/menugroups.service';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';
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
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      timeOut : 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: false,
    }),
  ],
  providers: [MenugroupsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
