import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../_Service/auth-service.service';
import { error } from '@angular/compiler/src/util';
import { AlertifyService } from '../_Service/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
model:any={};
  constructor( private authService:AuthServiceService, private alertify:AlertifyService) { }

  ngOnInit(): void {
  }
  register()
  {
    return this.authService.register(this.model).subscribe(()=>{
      this.alertify.success("Registeration Successfuly");  
      this.authService.loggedin=false;
    },error=>{
      this.alertify.error("Failed to Registeration");
    });
    
  }
  cancel()
  {
    this.alertify.warning("Canceled");
    
  }
  loggedIn()
  {
const User=localStorage.getItem("token");
return !!User;

  }
  logout()
  {
    localStorage.removeItem("token");
    this.alertify.message("logged out");
    
  }
  


}
