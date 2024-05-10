import { createAction, props } from "@ngrx/store";
import { Employee } from "../../shared/models/employee";

export const searchEmployee =createAction(
  "[Search Employee] Search",
  props<{employeeName: string}>()
)

export const onSearchEmployeeSuccess =createAction(
  "[Search Employee] Search Sucesss",
  props<{ employees: Employee[]}>()
)

export const addEmployee = createAction(
  "[Add Employee] Add",
  props<{employee: Employee}>()
)

export const updateEmployee = createAction(
  "[Update Employee] Update",
  props<{employee: Employee}>()
)



