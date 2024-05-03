import { Component } from '@angular/core';
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

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent {
  id:number=0
  Title: string = 'Employee : New Employee';
  //employee!: Employee;
  employeeForm = this.formBuilder.group<FormModel>({
    id: this.formBuilder.control({value: 0, disabled: true}),
    firstName: this.formBuilder.control(''),
    lastName: this.formBuilder.control(''),
    email: this.formBuilder.control('',[Validators.required, Validators.email]),
    description: this.formBuilder.control(''),
  });

  constructor(
    private route: ActivatedRoute,
    private service: EmployeeService,
    private formBuilder: FormBuilder
  ) {
    this.id = parseInt(this.route.snapshot.paramMap.get('id') as string);
    if (this.id > 0) this.SetTitle();
  }

  SetTitle() {
    this.GetEmployee();
  }

  GetEmployee() {
    this.service.Get(this.id).subscribe((data) => {
      this.employeeForm.patchValue(data);
      this.Title = `${this.employeeForm.controls.lastName.value}, ${this.employeeForm.controls.firstName.value}`;
    });
  }

  public submit() {
    let emp = <Employee>this.employeeForm.value;
    emp.id = this.id;
    if(emp.id > 0)
      this.service.Update(emp).subscribe((data) => console.log(data));
    else
      this.service.Create(emp).subscribe((data) => console.log(data));
  }

}

interface FormModel {
  id: FormControl<number | null>;
  firstName: FormControl<string | null>;
  lastName: FormControl<string | null>;
  email: FormControl<string | null>;
  description: FormControl<string | null>;
}
