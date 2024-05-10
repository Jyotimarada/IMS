import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EmployeeState } from "./employee.state";

export const selectEmployeeFeature = createFeatureSelector<EmployeeState>("employees");

export const selectEmployeeSearch = createSelector(
  selectEmployeeFeature,
  (state: EmployeeState) => state.searchString
)

export const selectEmployees = createSelector(
  selectEmployeeFeature,
  (state: EmployeeState) => state.employees
)

export const selectEmployeeDevices = createSelector(
  selectEmployeeFeature,
  (state: EmployeeState) => state.employeeDevices
)

export const selectEmployee = (props: {id: number}) =>
  createSelector(selectEmployees,
    (employees)  => employees.find((e) => e.id === props.id)
)

export const selectEmployeeDevicesById = (props: {id: number}) =>
  createSelector(selectEmployeeDevices,
    (employeeDevices)  => employeeDevices.find((e) => e.employeeId === props.id)
)
