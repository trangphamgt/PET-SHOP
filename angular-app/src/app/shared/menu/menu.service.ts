import { Injectable } from '@angular/core';
import { Menu } from './menu.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Menugroup } from './menugroup.model';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  readonly rootURL = "https://localhost:44344/api";
  listMenu : Menu[];
  formData : Menu;
  listMenuGroup : Menugroup[];
  constructor(private http: HttpClient) { }
  getListMenu(isAdmin? : boolean){
    this.http.get(this.rootURL+"/menu/GetByAdmin",
    {params: new HttpParams().set('IsAdmin','true')})
    .toPromise().then(res => this.listMenu = res as Menu[]);
  }

  getListMenuGroup(isAdmin? : boolean){
    this.http.get(this.rootURL+"/menu/GetMenuGroup",
    {params: new HttpParams().set('IsAdmin','true')})
    .toPromise().then(res => this.listMenu = res as Menu[]);
  }
}
