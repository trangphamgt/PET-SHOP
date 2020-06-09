import { Component, OnInit } from '@angular/core';
import { MenuService } from '@app/services';
import { Menu } from '@app/models';

@Component({
  selector: 'app-left-sidebar',
  templateUrl: './left-sidebar.component.html',
  styleUrls: ['./left-sidebar.component.css']
})
export class LeftSidebarComponent implements OnInit {

  constructor(private service : MenuService) { }
  lstMenu : Menu[];
  ngOnInit(): void {
    let role = 1;
    this.loadMenu(role);
    console.log(this.lstMenu)
  }

  loadMenu(role : number){
    this.service
      .getMenubyRole(role)
      .subscribe((res) => (this.lstMenu = res as Menu[]));

  }
}
