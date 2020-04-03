import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { MenugroupsService } from 'src/app/shared/menugroups.service';
@Component({
  selector: 'app-menugroup',
  templateUrl: './menugroup.component.html',
  styleUrls: ['./menugroup.component.css']
})
export class MenugroupComponent implements OnInit {

  constructor(public service : MenugroupsService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form != null){
      form.resetForm();
    }
    this.service.formData = {
      Id : null,
      Name : ''
    }
  }

  onSubmit(form : NgForm){
    this.insertRecord(form);
  }
  insertRecord(form : NgForm){
    this.service.addData(form.value).subscribe();
  }
}
