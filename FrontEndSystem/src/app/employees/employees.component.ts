import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  constructor( private http:HttpClient) { }
  Employees:any;
  ngOnInit(): void {
  }
  getEmployee()
  {
this.http.get("https://localhost:5001/api/EmployeeAuth/getEmployee").subscribe(
  response =>{this.Employees=response;},
error=>{console.log(error);})
}
}
