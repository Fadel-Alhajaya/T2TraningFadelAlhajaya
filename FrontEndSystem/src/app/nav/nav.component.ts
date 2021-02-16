import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../_Service/auth-service.service';
import { error } from '@angular/compiler/src/util';
import { AlertifyService } from '../_Service/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model :any={};
  users:string;

  constructor( private authService:AuthServiceService, private alertfy:AlertifyService) { }

  ngOnInit(): void {
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

}
