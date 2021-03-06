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

  constructor( private http:HttpClient,public auth:AuthServiceService, private alert:AlertifyService) { }

  ngOnInit(): void {
  }
  login()
  {
  this.auth.Mangerlogin(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 this.users=this.auth.decodedToken;
 
  },error=>
  {
  this.alert.error("failed to login");
  console.log(localStorage.getItem("token"));
  
  
  })
  
    
  }
  
  loggedIn()
  {
    return this.auth.loggedIn();

  }
  logout()
  {
    localStorage.removeItem("token");
    this.alert.message(" Manger logged out");
    
  }
 

Switch(){

  localStorage.removeItem("token");


}
rejesterToggel()
{
  this.registerMode=!this.registerMode;
}
}
