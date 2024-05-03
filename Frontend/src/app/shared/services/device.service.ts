import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Device } from "../models/device.model";

@Injectable({providedIn: 'root'})
export class DeviceService
{
  constructor(private http : HttpClient){}

  public SearchByName(search: string) : Observable<Device[]>
  {
     return this.http.get<Device[]>(`https://localhost:7167/api/devices?s=${ search }`, {observe: 'body', responseType: 'json'})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Get(id: number) : Observable<Device>
  {
     return this.http.get<Device>(`https://localhost:7167/api/devices/${ id }`, {observe: 'body', responseType: 'json'})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Update(device : Device) : Observable<any>
  {

    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(device);
    console.log('inside save');
    console.log(body)
    return this.http.patch(`https://localhost:7167/api/devices/${ device.id }`, body, {'headers': headers})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }

  public Create(device : Device) : Observable<any>
  {

    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(device);
    console.log('inside save');
    console.log(body)
    return this.http.post(`https://localhost:7167/api/devices`, body, {'headers': headers})
    .pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError('Something went wrong.');
      })
    );;
  }
}
