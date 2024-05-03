import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { Device } from '../../../shared/models/device.model';
import { MatTableDataSource } from '@angular/material/table';
import { DeviceService } from '../../../shared/services/device.service';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrl: './device-list.component.css',
})
export class DeviceListComponent {
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: DeviceService, private modalRef: MatDialog) {
    this.OnSearch();
  }

  OnSearch() {
    console.log(this.search);
    this.service.SearchByName(this.search).subscribe((data) => {
      this.dataSource = new MatTableDataSource<Device>(data);
      this.dataSource.paginator = this.paginator
      console.log(data);
    });
  }

  OnClear() {
    this.search = '';
    this.OnSearch();
  }

  displayedColumns: string[] = [
    'id',
    'name',
    'description',
    'type',
    'shared',
    'barcode',
  ];
  dataSource = new MatTableDataSource<Device>();
  search: string = '';
}
