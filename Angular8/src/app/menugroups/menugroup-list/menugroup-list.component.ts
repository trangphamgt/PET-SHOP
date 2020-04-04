import { Component, OnInit } from '@angular/core';
import { MenugroupsService } from 'src/app/shared/menugroups.service';
import { Menugroup } from 'src/app/shared/menugroup.model';

@Component({
  selector: 'app-menugroup-list',
  templateUrl: './menugroup-list.component.html',
  styleUrls: ['./menugroup-list.component.css']
})
export class MenugroupListComponent implements OnInit {

  constructor(public service : MenugroupsService) { 
    
  }

  ngOnInit(): void {
    this.service.getList();
  }
  populateForm(mg : Menugroup){
    this.service.formData = mg;

  }

}
