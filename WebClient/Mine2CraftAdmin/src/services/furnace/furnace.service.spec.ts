import { TestBed } from '@angular/core/testing';

import { FurnaceService } from './furnace.service';

describe('UserService', () => {
  let service: FurnaceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FurnaceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
