import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Employee, EmployeeDevice } from "../models/employee";
import { Device } from "../models/device.model";

interface AssignDevices
{
  deviceId: number,
  assignedDate: Date;
}

@Injectable({providedIn: 'root'})
export class EmployeeService
{
  AssignDevices(id: number, devices: Device[]) {
    const headers = { 'content-type': 'application/json'}
    const empDev = devices.map((device) => ({ deviceId: device.id, assignedDate: new Date().toISOString()}))
    const body=JSON.stringify(empDev);
    console.log(empDev);
    return this.http.post(`https://localhost:7167/api/employees/${id}/assign-devices`, body, {'headers': headers})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;

  }
  constructor(private http : HttpClient){}
  employees : Employee[] | undefined

  public SearchByName(search: string) : Observable<Employee[]>
  {
     return this.http.get<Employee[]>(`https://localhost:7167/api/employees?s=${ search }`, {observe: 'body', responseType: 'json'})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Get(id: number) : Observable<Employee>
  {
     return this.http.get<Employee>(`https://localhost:7167/api/employees/${ id }`, {observe: 'body', responseType: 'json'})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public GetEmployeeDevices(id: number) : Observable<EmployeeDevice[]>
  {
     return this.http.get<EmployeeDevice[]>(`https://localhost:7167/api/employees/${ id }/devices`, {observe: 'body', responseType: 'json'})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Update(employee : Employee) : Observable<any>
  {

    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(employee);
    console.log('inside save');
    console.log(body)
    return this.http.patch(`https://localhost:7167/api/employees/${ employee.id }`, body, {'headers': headers})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Create(employee : Employee) : Observable<any>
  {

    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(employee);
    console.log('inside save');
    console.log(body)
    return this.http.post(`https://localhost:7167/api/employees`, body, {'headers': headers})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }
}
