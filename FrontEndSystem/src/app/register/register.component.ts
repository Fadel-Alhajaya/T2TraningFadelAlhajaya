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
    },error=>{
      this.alertify.error("Failed to Registeration");
    });
    
  }
  cancel()
  {
    this.alertify.warning("Canceled");
    
  }
  


}
