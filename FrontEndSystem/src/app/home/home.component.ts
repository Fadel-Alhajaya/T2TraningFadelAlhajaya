import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  constructor( private http:HttpClient) { }
  Employees:any;
  ngOnInit(): void {
  this.getEmployee();
  }
  rejesterToggel()
  {
    this.registerMode=!this.registerMode;
  }
  getEmployee()
  {
this.http.get("https://localhost:5001/api/EmployeeAuth/getEmployee").subscribe(
  response =>{this.Employees=response;},
error=>{console.log(error);})
}
}
