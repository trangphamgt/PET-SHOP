import { Component, OnInit, OnDestroy } from '@angular/core';
import { MenuService } from '../shared/menu/menu.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnDestroy {
  routerSubscription: any;
  constructor(public service: MenuService) { }

  ngOnInit(): void {
    this.service.getListMenu(true);
  }
  ngOnDestroy(){
  }
  

}
