import { Injectable } from '@angular/core';
import { Register } from './register.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  formData : Register;
  readonly rootURL =  "https://localhost:44344/account";
  constructor(public http : HttpClient) { }

  registerUser(formData : Register){
    return this.http.post(this.rootURL, formData);
  }

}
