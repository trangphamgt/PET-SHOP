import { Component, OnInit } from '@angular/core';
import { MenuGroupService } from 'src/app/shared/menu-group.service';

@Component({
  selector: 'app-menugroup-list',
  templateUrl: './menugroup-list.component.html',
  styleUrls: ['./menugroup-list.component.css']
})
export class MenugroupListComponent implements OnInit {

  constructor(public service : MenuGroupService) { }

  ngOnInit(): void {
    this.service.refeshList();
  }

}
