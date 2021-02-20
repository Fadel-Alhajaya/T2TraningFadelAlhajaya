import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../_Service/auth-service.service';
import { error } from '@angular/compiler/src/util';
import { AlertifyService } from '../_Service/alertify.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model :any={};
  users:string;
  Employees:any;
  registerMode=false;
  constructor( private http:HttpClient, private authService:AuthServiceService, private alertfy:AlertifyService) {
    
   }

  ngOnInit(): void {
    this.getEmployee();
  }
  login()
  {
  this.authService.login(this.model).subscribe(next=>{
 this.alertfy.success("logged in Successfuly");
 this.users=this.authService.name;
 
  },error=>
  {
  this.alertfy.error("failed to login");
  
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
    this.alertfy.message("logged out");
    
  }
  getEmployee()
  {
this.http.get("https://localhost:5001/api/EmployeeAuth/getEmployee").subscribe(
  response =>{this.Employees=response;},
error=>{console.log(error);})
}
rejesterToggel()
{
  this.registerMode=!this.registerMode;
}
Switch(){

  localStorage.removeItem("user");


}

}

 
 


