import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { EmployeeService } from '../../../shared/services/emplyee.service';
import { Employee } from '../../../shared/models/employee';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeComponent } from '../employee/employee.component';
import { EmployeeDevicesComponent } from '../employee-devices/employee-devices.component';
import { Store } from '@ngrx/store';
import {searchEmployee, selectEmployeeSearch } from '../../../state/employee'
import { Observable } from 'rxjs';
import { selectEmployee,selectEmployeeDevices,selectEmployees} from '../../../state/employee';

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrl: './employeelist.component.css',
})
export class EmployeelistComponent {
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  employees$!: Observable<Employee[]>;
  searchString$!: Observable<string>;

  constructor(private service: EmployeeService, private modalRef: MatDialog,private store: Store){
    this.employees$ = store.select(selectEmployees);
    this.searchString$ = store.select(selectEmployeeSearch)
    this.employees$.subscribe((data) => {
      console.log(data);
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
    }
    );

    this.searchString$.subscribe((search) => this.search = search);
  }


  OpenEmployeeDevices(employee : Employee) {
    const dialogRef = this.modalRef.open(EmployeeDevicesComponent, {
     data: employee});
  }

  OnSearch() {
    this.store.dispatch(searchEmployee({employeeName: this.search}));
  }
OnClear() {
 this.search = '';
  this.OnSearch();
  }
  employees : Employee[] | undefined;
  displayedColumns: string[] = ['id', 'name', 'email', 'devices'];
  dataSource = new MatTableDataSource<Employee>();
  search: string = "";

}

