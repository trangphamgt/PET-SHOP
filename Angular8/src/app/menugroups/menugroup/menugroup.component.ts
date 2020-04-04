import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { MenugroupsService } from 'src/app/shared/menugroups.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-menugroup',
  templateUrl: './menugroup.component.html',
  styleUrls: ['./menugroup.component.css']
})
export class MenugroupComponent implements OnInit {

  constructor(public service : MenugroupsService, private toastr: ToastrService) { }

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
    if(form.value.Id == null)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }
  insertRecord(form : NgForm){
    this.service.addData(form.value).subscribe(res => {
      debugger;
      this.toastr.success('Inserted Successfully','Menugroup');
      this.resetForm(form);
      this.service.getList();
    });
  }
  updateRecord(form : NgForm){
    debugger;
    this.service.putData(form.value).subscribe(res => {
      debugger;
      this.toastr.success('Updated Successfully','Menugroup');
      this.resetForm(form);
      this.service.getList();
    });
  }
}
