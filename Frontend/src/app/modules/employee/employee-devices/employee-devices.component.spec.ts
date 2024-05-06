import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDevicesComponent } from './employee-devices.component';

describe('EmployeeDevicesComponent', () => {
  let component: EmployeeDevicesComponent;
  let fixture: ComponentFixture<EmployeeDevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeDevicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmployeeDevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
