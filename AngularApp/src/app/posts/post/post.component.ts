import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/shared/post.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor(public service: PostService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form !=null)
      form.resetForm();
    this.service.formData = {
      Id : null,
      Alias : '',
      CategoryId : null,
      Content : '',
      Description : '',
      HomeFlag : null,
      HotFlag : null,
      Image : '',
      Name : '',
      MetaKeyword:'',
      ViewCount : null,
      CreatedBy: null,
      CreatedDate: null,
      MetaDescription: null,
      Status: null,
      UpdatedBy: null,
      UpdatedDate: ''
    }
  }

  onSubmit(form: NgForm){
    this.insertRecord(form);
  }
  insertRecord(form : NgForm){
    this.service.addPost(form.value).subscribe(res=>{
      this.resetForm(form);
    });
  }
  getAllRecord(){
    
  }
}
