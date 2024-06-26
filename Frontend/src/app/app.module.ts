import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button'
import { MatDividerModule } from '@angular/material/divider'
import {CommonModule} from '@angular/common'
import { RouterModule } from '@angular/router';
import { EmployeeModule } from './modules/employee/employee.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { StoreModule } from "@ngrx/store";
import { reducers, metaReducers } from "./state";
import { EffectsModule } from '@ngrx/effects';

import { EmloyeeEffects}  from './state/employee'



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatDividerModule,
    CommonModule,
    EmployeeModule,
    HttpClientModule,StoreModule.forRoot(reducers, {metaReducers}),
    EffectsModule.forRoot([EmloyeeEffects])
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
