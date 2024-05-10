import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EmployeeService } from '../../shared/services/emplyee.service';
import { Injectable } from '@angular/core';
import * as EmployeeActions from './employee.actions';
import { EMPTY, catchError, map, switchMap, tap } from 'rxjs';

@Injectable()
export class EmloyeeEffects {
  constructor(
    private actions$: Actions<any>,
    private service: EmployeeService
  ) {}

  searchEmployees$ = createEffect(() =>
    this.actions$.pipe(
      ofType(EmployeeActions.searchEmployee.type),
      switchMap((action) =>
        this.service.SearchByName(action.employeeName).pipe(
          map((employeess) =>
            EmployeeActions.onSearchEmployeeSuccess({ employees: employeess })
          ),
          catchError(() => EMPTY)
        )
      )
    )
  )  ;

  init$ = createEffect(
    () => this.actions$.pipe(tap((action) => console.log(action))),
    { dispatch: false }
  );
}
