import { Component, InjectionToken, Injector } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../../shared/models/employee';
import { EmployeeService } from '../../../shared/services/emplyee.service';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl,
  FormArray,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DeviceListComponent } from '../../device/device-list/device-list.component';
import { Device } from '../../../shared/models/device.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent {
  id: number = 0;
  Title: string = 'Employee : New Employee';
  isDataLoaded = false;

  employee!: Employee;
  employeeForm = this.formBuilder.group<FormModel>({
    id: this.formBuilder.control({ value: 0, disabled: true }),
    firstName: this.formBuilder.control(''),
    lastName: this.formBuilder.control(''),
    email: this.formBuilder.control('', [
      Validators.required,
      Validators.email,
    ]),
    description: this.formBuilder.control(''),
  });

  constructor(
    private route: ActivatedRoute,
    private service: EmployeeService,
    private formBuilder: FormBuilder,
    private modalRef: MatDialog,
    private _messageBar: MatSnackBar
  ) {
    this.id = parseInt(this.route.snapshot.paramMap.get('id') as string);
    if (this.id > 0) this.GetEmployee();
  }

  openMessageBar(message: string, action: string) {
    this._messageBar.open(message, action,{duration:2000, verticalPosition : 'top'});
  }

  SetTitle() {
    this.Title = `${this.employeeForm.controls.lastName.value}, ${this.employeeForm.controls.firstName.value}`;
  }


  GetEmployee() {
    this.service.Get(this.id).subscribe((data) => {
      this.employeeForm.patchValue(data);
      this.Title = `${this.employeeForm.controls.lastName.value}, ${this.employeeForm.controls.firstName.value}`;
      this.employee = <Employee>this.employeeForm.value;
      this.isDataLoaded = true;
      this.SetTitle();
    });
  }
  get getEmployeeData(): Employee {
    let emp = <Employee>this.employeeForm.value;
    emp.id = this.id;
    return emp;
  }

  public submit() {
    let emp = <Employee>this.employeeForm.value;
    emp.id = this.id;
    if (emp.id > 0)
    {
      this.service.Update(emp).subscribe((data) => this.openMessageBar("Updated Successfully",""));
      this.SetTitle();
    }
    else 
    this.service.Create(emp).subscribe((data) => this.openMessageBar("Created Successfully",""));
  }

  OpenDeviceSelection() {
    const dialogRef = this.modalRef.open(DeviceListComponent);
    dialogRef.componentInstance.AllowSelection = true;
    dialogRef.componentInstance.Selected.subscribe((selection) => {
      this.AssignSelectedDevices(selection);
      dialogRef.componentInstance.Selected.unsubscribe();
      dialogRef.close();
    });
  }

  AssignSelectedDevices(devices: Device[]) {
    this.service.AssignDevices(this.id, devices).subscribe(data => {
      this.isDataLoaded = false;
      setTimeout(() => {
        this.isDataLoaded = true
      }, 20);
    });
  }
}

interface FormModel {
  id: FormControl<number | null>;
  firstName: FormControl<string | null>;
  lastName: FormControl<string | null>;
  email: FormControl<string | null>;
  description: FormControl<string | null>;
}
