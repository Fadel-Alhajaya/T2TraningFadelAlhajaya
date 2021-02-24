import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthServiceService } from '../_Service/auth-service.service';
import { AlertifyService } from '../_Service/alertify.service';

@Component({
  selector: 'app-mange',
  templateUrl: './mange.component.html',
  styleUrls: ['./mange.component.css']
})
export class MangeComponent implements OnInit {
  model:any={};
  registerMode=false;
  users: string;

  constructor( private http:HttpClient,private auth:AuthServiceService, private alert:AlertifyService) { }

  ngOnInit(): void {
  }
  login()
  {
  this.auth.Mangerlogin(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 this.users=this.auth.name;
 
  },error=>
  {
  this.alert.error("failed to login");
  console.log(localStorage.getItem("user"));
  
  
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
    this.alert.message(" Manger logged out");
    
  }
 

Switch(){

  localStorage.removeItem("user");


}
rejesterToggel()
{
  this.registerMode=!this.registerMode;
}
}
