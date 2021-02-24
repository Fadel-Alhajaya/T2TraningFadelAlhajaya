import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthServiceService } from '../_Service/auth-service.service';
import { AlertifyService } from '../_Service/alertify.service';

@Component({
  selector: 'app-manger-register',
  templateUrl: './manger-register.component.html',
  styleUrls: ['./manger-register.component.css']
})
export class MangerRegisterComponent implements OnInit {
  model: any={};
  registerMode: boolean=false;
  manger: string;

  constructor(private http:HttpClient, private authService:AuthServiceService, private alert:AlertifyService ) { }

  ngOnInit(): void {
  }
  register()
  {
    return this.authService.MangerRegister(this.model).subscribe(()=>{
      this.alert.success("Registeration Successfuly");  
      this.authService.loggedin=false;
    },error=>{
      this.alert.error("Failed to Registeration");
    });
    
  }
  login()
  {
  this.authService.Mangerlogin(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 this.manger=this.authService.name;
 
  },error=>
  {
  this.alert.error("failed to login");
  
  });
}
  cancel()
  {
    this.alert.warning("Canceled");
    
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

  

