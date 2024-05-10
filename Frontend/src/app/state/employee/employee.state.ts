import { Employee, EmployeeDevice } from "../../shared/models/employee";

export interface EmployeeState{
  searchString: string;
  employees: Employee[];
  employeeDevices : EmployeeDevice[];
}

export const initialState : EmployeeState = { employees:[], employeeDevices:[],searchString:'' }
