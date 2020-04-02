import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../shared/register.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  constructor(public service: RegisterService) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.registerUser(form.value).subscribe;
  }
}
