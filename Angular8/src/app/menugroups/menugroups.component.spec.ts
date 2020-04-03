import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenugroupsComponent } from './menugroups.component';

describe('MenugroupsComponent', () => {
  let component: MenugroupsComponent;
  let fixture: ComponentFixture<MenugroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenugroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenugroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
