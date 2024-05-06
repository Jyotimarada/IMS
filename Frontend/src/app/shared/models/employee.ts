export interface Employee {
  id: number
  firstName: string;
  lastName: string;
  email: string;
  description:string;
  devices?: number;
}

export interface EmployeeDevice{
  employeeId: number,
  employeeName: string,
  deviceId: number,
  devicename: string,
  assignedDate: Date,
  returnDate: Date

}
