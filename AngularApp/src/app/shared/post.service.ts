import { Injectable } from '@angular/core';
import { Post } from './post.model';
import{HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class PostService {
  formData : Post;
  readonly rootURL =  "https://localhost:44344/api";

  constructor(public http : HttpClient) { }
  addPost(formData : Post){
    return this.http.post(this.rootURL+'/post', formData);
  }
}
