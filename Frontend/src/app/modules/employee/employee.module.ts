import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { CommonModule } from '@angular/common';
import { EmployeelistComponent } from './employeelist/employeelist.component';
import { Routes,RouterModule  } from '@angular/router';
import { MatPaginatorModule} from '@angular/material/paginator';
import { MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button'
import { MatInputModule } from '@angular/material/input'
import { MatTooltipModule } from '@angular/material/tooltip';
import { EmployeeComponent } from './employee/employee.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from '@angular/forms'


const routes: Routes = [
  { path: '', component: EmployeelistComponent, pathMatch:'full'  },
  { path: 'employees/:id', component: EmployeeComponent, pathMatch:'full'  }]

@NgModule({
  declarations: [
    EmployeelistComponent,
    EmployeeComponent
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
    ReactiveFormsModule

  ],
  exports: [RouterModule],

})
export class EmployeeModule { }
