import { AfterViewInit, Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Device } from '../../../shared/models/device.model';
import { MatTableDataSource } from '@angular/material/table';
import { DeviceService } from '../../../shared/services/device.service';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrl: './device-list.component.css',
})
export class DeviceListComponent {
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @Input('AllowSelection') AllowSelection : boolean = false
  @Output() Selected = new EventEmitter<Device[]>();

  constructor(private service: DeviceService, private modalRef: MatDialog) {
  }

  ngOnInit() {
    this.SetColumns();
    this.OnSearch();
  }

  OnSearch() {
    this.service.SearchByName(this.search,this.AllowSelection).subscribe((data) => {
      this.dataSource = new MatTableDataSource<Device>(data);
      this.dataSource.paginator = this.paginator
    });
  }

  OnClear() {
    this.search = '';
    this.OnSearch();
  }


  displayedColumns: string[] = [
    'select',
    'id',
    'name',
    'description',
    'type',
    'shared',
    'barcode',
  ];
  dataSource = new MatTableDataSource<Device>();
  search: string = '';
  selection = new SelectionModel<Device>(true, []);

  SetColumns()
  {
    if(!this.AllowSelection)
      this.displayedColumns =  [
        'id',
        'name',
        'description',
        'type',
        'shared',
        'barcode',
      ];
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Device): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  SelectedDevices()
  {
    this.Selected.emit(this.selection.selected);
  }
}
