import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenugroupListComponent } from './menugroup-list.component';

describe('MenugroupListComponent', () => {
  let component: MenugroupListComponent;
  let fixture: ComponentFixture<MenugroupListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenugroupListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenugroupListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
