import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../_Service/auth-service.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
model:any={};
  constructor( private authService:AuthServiceService) { }

  ngOnInit(): void {
  }
  register()
  {
    return this.authService.register(this.model).subscribe(()=>{
      console.log("Registeration Successfuly");  
    },error=>{
      console.log(error);
    });
    
  }
  cancel()
  {
    console.log("Canceled");
    
  }
  


}
