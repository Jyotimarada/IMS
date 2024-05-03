import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeModule } from './modules/employee/employee.module';
import { AppComponent } from './app.component';
import { DeviceModule } from './modules/device/device.module';

const routes: Routes = [
  { path: '', redirectTo:'/employees', pathMatch:"full" },
  {
    path: 'employees',
    loadChildren: () => EmployeeModule
  },
  {
    path: 'devices',
    loadChildren: () => DeviceModule
  },
];


@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
