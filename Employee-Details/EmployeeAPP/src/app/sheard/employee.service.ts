import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private myHttp:HttpClient) { }

  employeeData:Employee[] = [] //Getting data employeelist
  employee:Employee = new Employee() //Insert Data
  employeeUrl:string = environment.baseUrl + "Employees"

  //Getting All Record
  getEmployees():Observable<Employee[]>{
    return this.myHttp.get<Employee[]>(this.employeeUrl);
  }

  //Insert Redord
  postEmployee(){
    return this.myHttp.post(this.employeeUrl, this.employeeData);
  }
  
}
