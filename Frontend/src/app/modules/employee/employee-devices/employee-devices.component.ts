import { Component, Inject, Input, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee, EmployeeDevice } from '../../../shared/models/employee';
import { EmployeeService } from '../../../shared/services/emplyee.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-employee-devices',
  templateUrl: './employee-devices.component.html',
  styleUrl: './employee-devices.component.css'
})
export class EmployeeDevicesComponent {
Title: string='';
dataSource = new MatTableDataSource<EmployeeDevice>();
displayedColumns: string[] = [ 'devicename', 'assignedDate'];
@Input('showToolBar') showToolBar = true;
@Input('employee') employeeData: Employee = {id:0,firstName: '', lastName: '',email:'',description:'' };


  constructor(@Optional() @Inject(MAT_DIALOG_DATA) public employee: Employee,private service: EmployeeService,)
  {


  }
  GetDevices(id: number) {
    this.service.GetEmployeeDevices(id).subscribe((data) => {this.dataSource = new MatTableDataSource<EmployeeDevice>(data);

    });
  }
  ngOnInit() {
    console.log(this.employee);
    console.log(this.employeeData);

    this.employee = this.employee ?? this.employeeData;
    console.log(this.employee.id);
      this.GetDevices(this.employee.id);
      this.Title = `${this.employee?.lastName}, ${this.employee?.firstName}`;
  }
}


