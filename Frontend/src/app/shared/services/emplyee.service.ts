import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Employee } from "../models/employee";

@Injectable({providedIn: 'root'})
export class EmployeeService
{
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
