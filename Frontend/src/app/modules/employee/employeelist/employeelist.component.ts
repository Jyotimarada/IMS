import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { EmployeeService } from '../../../shared/services/emplyee.service';
import { Employee } from '../../../shared/models/employee';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeComponent } from '../employee/employee.component';

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrl: './employeelist.component.css',
})
export class EmployeelistComponent {
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: EmployeeService, private modalRef: MatDialog){
    this.OnSearch();
  }
  OnSearch() {
console.log(this.search);
this.service.SearchByName(this.search).subscribe(data => {this.dataSource = new MatTableDataSource<Employee>(data);
  this.dataSource.paginator = this.paginator
});
console.log(this.employees);
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

