import { Action, createReducer, on } from "@ngrx/store";

import * as EmployeeActions from "./employee.actions"

import { EmployeeState, initialState } from "./employee.state";

export const employeeReducer = createReducer(
  initialState,
  on(EmployeeActions.searchEmployee, (state, { employeeName }) =>({...state, searchString: employeeName}) ),
  on(EmployeeActions.onSearchEmployeeSuccess, (state, { employees }) =>
    ({
      ...state,
      employees: employees
     }) ),
  on(EmployeeActions.addEmployee, (state, { employee }) => {
    state.employees.push(employee);
    return {
      ...state,
      employee
    };
  }),
  on(EmployeeActions.updateEmployee, (state, { employee }) => {

    const employeeIndex = state.employees.findIndex((e) => e.id === employee.id);
    const updatedEmployees = [...state.employees];
    updatedEmployees[employeeIndex] = employee;
    state.employees = updatedEmployees;
    return {
      ...state,
      employee
    };
  })
);

export function reducer(state: EmployeeState | undefined, action: Action) {
  return employeeReducer(state, action);
}
