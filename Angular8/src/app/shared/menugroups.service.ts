import { Injectable } from '@angular/core';
import { Menugroup } from './menugroup.model';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class MenugroupsService {

  formData : Menugroup;
  readonly rootURL = "https://localhost:44344/api/MenuGroups";
  constructor(public http : HttpClient) { }
  addData(formData : Menugroup){
    console.log(formData);
    debugger;
    return this.http.post(this.rootURL+ "/PostMenuGroup",formData);
  }
}
