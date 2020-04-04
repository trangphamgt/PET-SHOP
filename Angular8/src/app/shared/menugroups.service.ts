import { Injectable } from '@angular/core';
import { Menugroup } from './menugroup.model';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class MenugroupsService {

  formData : Menugroup;
  list : Menugroup[];
  readonly rootURL = "https://localhost:44344/api";
  constructor(public http : HttpClient) {
   }
  
  
  addData (formData : Menugroup) {
    return this.http.post(this.rootURL+'/MenuGroups',formData);
  }
  getList(){
    return this.http.get(this.rootURL+'/MenuGroups').toPromise().then(res=> this.list = res as Menugroup[]);
  }
  putData (formData : Menugroup) {
    return this.http.put(this.rootURL+'/MenuGroups/'+formData.Id,formData);
  }
}
