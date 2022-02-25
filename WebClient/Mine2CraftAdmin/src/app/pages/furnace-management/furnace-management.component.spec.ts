import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FurnaceManagementComponent } from './furnace-management.component';

describe('UserManagementComponent', () => {
  let component: FurnaceManagementComponent;
  let fixture: ComponentFixture<FurnaceManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FurnaceManagementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FurnaceManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
