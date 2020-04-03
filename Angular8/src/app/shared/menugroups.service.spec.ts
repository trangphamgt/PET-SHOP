import { TestBed } from '@angular/core/testing';

import { MenugroupsService } from './menugroups.service';

describe('MenugroupsService', () => {
  let service: MenugroupsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MenugroupsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
