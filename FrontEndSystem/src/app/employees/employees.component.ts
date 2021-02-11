import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
 Employees:any;
  constructor( private http:HttpClient) { }

  ngOnInit(): void {
    this.getEmployee();
  }

  getEmployee()
  {
this.http.get("https://localhost:44385/api/EmployeeAuth/getEmployee").subscribe(
  response =>{this.Employees=response;},
error=>{console.log("error");})
}
  }
  


