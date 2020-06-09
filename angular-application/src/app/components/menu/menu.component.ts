import { Component, OnInit } from '@angular/core';
import { MenuService } from '@app/services';
import { Menu } from '@app/models';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: "Hydrogen", weight: 1.0079, symbol: "H" },
  { position: 2, name: "Helium", weight: 4.0026, symbol: "He" },
  { position: 3, name: "Lithium", weight: 6.941, symbol: "Li" },
  { position: 4, name: "Beryllium", weight: 9.0122, symbol: "Be" },
  { position: 5, name: "Boron", weight: 10.811, symbol: "B" },
  { position: 6, name: "Carbon", weight: 12.0107, symbol: "C" },
  { position: 7, name: "Nitrogen", weight: 14.0067, symbol: "N" },
  { position: 8, name: "Oxygen", weight: 15.9994, symbol: "O" },
  { position: 9, name: "Fluorine", weight: 18.9984, symbol: "F" },
  { position: 10, name: "Neon", weight: 20.1797, symbol: "Ne" },
];

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  lstMenu: Menu[];
  displayedColumns: string[] = ["Id", "Name", "Status", "DisplayOrder"];
  dataSource = [];
  constructor(private service: MenuService) {}

  ngOnInit(): void {
    let role = 1;
    this.loadMenu(role);
    this.dataSource = this.lstMenu;
  }

  loadMenu(role: number) {
    this.service
      .getMenubyRole(role)
      .subscribe((res) => {
        (this.lstMenu = res as Menu[])
        this.dataSource = this.lstMenu;
      });
  }
}
