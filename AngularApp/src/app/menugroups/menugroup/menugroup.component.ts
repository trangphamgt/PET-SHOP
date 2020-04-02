import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {MenuGroupService} from 'src/app/shared/menu-group.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-menugroup',
  templateUrl: './menugroup.component.html',
  styleUrls: ['./menugroup.component.css']
})
export class MenugroupComponent implements OnInit {

  constructor(public service : MenuGroupService,
    public toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(form: NgForm){
    this.insertRecord(form);
  }
  insertRecord(form : NgForm){
    this.service.addMenuGroup(form.value).subscribe(res=>{
      this.toastr.success("Inserted Successfully","MENUGROUP .Register")
      this.resetForm(form);
    });
  }
  
  resetForm(form? : NgForm){
    if(form !=null)
      form.resetForm();
    this.service.formData = {
      Id : null,
      Name :''
    }
  }
}
