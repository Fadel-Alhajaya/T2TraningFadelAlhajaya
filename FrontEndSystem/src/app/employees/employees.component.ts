import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AlertifyService } from '../_Service/alertify.service';
import { AuthServiceService } from '../_Service/auth-service.service';
import { EmployeeService } from '../_Service/employee.service';
import { Employee } from '../_models/employee';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  model: any={};
  
  url=environment.baseUrl;
  Employees:Employee[];
  registerMode=false;
  

  constructor( private http:HttpClient, private alert:AlertifyService, public auth:AuthServiceService, private employeeService:EmployeeService) { }
 
  ngOnInit(): void {
    this.getEmployee();
  }
  login()
  {
  this.auth.login(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 
 
  },error=>
  {
  this.alert.error("failed to login");
  
  })
  
    
  }
  
  loggedIn()
  {
const User=localStorage.getItem("token");
return !!User;

  }
  logout()
  {
    localStorage.removeItem("token");
    this.alert.message("logged out");
    
  }
 

Switch(){

  localStorage.removeItem("token");


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
//getSingelEmployee()


 // this.employeeService.getSingelEmployee(+this.auth.decodedToken?.nameid)._subscribe()=>
 //   {
 //     console.log("all employee"),
 //   },
 // )
//}
}
