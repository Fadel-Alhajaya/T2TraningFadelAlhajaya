import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../_Service/auth-service.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model :any={};

  constructor( private authService:AuthServiceService) { }

  ngOnInit(): void {
  }
  login()
  {
  this.authService.login(this.model).subscribe(next=>{
 console.error("logged in Successfuly");
 
  },error=>
  {
  console.error("failed to login");
  
  })
  
    
  }

}
