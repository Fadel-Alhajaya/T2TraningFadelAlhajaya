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
  registerMode=false;
  constructor( private http:HttpClient, public authService:AuthServiceService, private alertfy:AlertifyService) {
    
   }

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
return this.authService.loggedIn();

  }
  logout()
  {
    localStorage.removeItem("token");
    this.alertfy.message("logged out");
    
  }
 
rejesterToggel()
{
  this.registerMode=!this.registerMode;
}
Switch(){

  localStorage.removeItem("token");


}

}

 
 


