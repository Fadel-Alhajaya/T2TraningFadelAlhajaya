import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AlertifyService } from '../_Service/alertify.service';
import { AuthServiceService } from '../_Service/auth-service.service';
import { EmployeeService } from '../_Service/employee.service';
import { Employee } from '../_models/employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  model: any={};
  users: string;
  url=environment.baseUrl;
  Employees:Employee[];
  registerMode=false;

  constructor( private http:HttpClient, private alert:AlertifyService, private auth:AuthServiceService, private employeeService:EmployeeService) { }
 
  ngOnInit(): void {
    this.getEmployee();
  }
  login()
  {
  this.auth.login(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 this.users=this.auth.name;
 
  },error=>
  {
  this.alert.error("failed to login");
  
  })
  
    
  }
  
  loggedIn()
  {
const User=localStorage.getItem("user");
return !!User;

  }
  logout()
  {
    localStorage.removeItem("user");
    this.alert.message("logged out");
    
  }
 

Switch(){

  localStorage.removeItem("user");


}
rejesterToggel()
{
  this.registerMode=!this.registerMode;
}
  getEmployee()
  {
 
 this.employeeService.getAllEmployee().subscribe((Employees:Employee[])=> 
 {
    this.Employees=Employees;
     console.log("all employee");
     
},
error=>{this.alert.error("Error !!");
console.log("Employee error");
});
}
}
