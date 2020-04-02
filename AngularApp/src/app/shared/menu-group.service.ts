import { Injectable } from '@angular/core';
import {MenuGroup} from '../shared/menu-group.model';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class MenuGroupService {
  formData : MenuGroup;
  list: MenuGroup[];
  readonly rootURL =  "https://localhost:44344/api";

  constructor(public http : HttpClient) { }
  addMenuGroup(formData : MenuGroup){
    return this.http.post(this.rootURL+'/menugroups', formData);
  }
refeshList(){
  this.http.get(this.rootURL +"/menugroups")
  .toPromise().then(res => this.list = res as MenuGroup[]);
}

}
