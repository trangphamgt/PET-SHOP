import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountLogin } from './account-login.model';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  urlRoot = "localhost:";

  constructor(private http : HttpClient) { }

  Login(formData : AccountLogin){
    return this.http.get(this.urlRoot+"/account").subscribe();
  }
}
