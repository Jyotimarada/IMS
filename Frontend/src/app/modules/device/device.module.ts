import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { CommonModule } from '@angular/common';
import { Routes,RouterModule  } from '@angular/router';
import { MatPaginatorModule} from '@angular/material/paginator';
import { MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button'
import { MatInputModule } from '@angular/material/input'
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ReactiveFormsModule } from '@angular/forms'
import { DeviceListComponent } from './device-list/device-list.component';
import { DeviceComponent } from './device/device.component';


const routes: Routes = [
  { path: '', component: DeviceListComponent, pathMatch:'full'  },
  { path: ':id', component: DeviceComponent, pathMatch:'full'  }]

@NgModule({
  declarations: [
    DeviceListComponent,
    DeviceComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatPaginatorModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    FormsModule,
    MatTooltipModule,
    MatDialogModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatAutocompleteModule
  ],
  exports:[
    RouterModule
  ]
})
export class DeviceModule { }
