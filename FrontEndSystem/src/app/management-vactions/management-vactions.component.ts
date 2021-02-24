import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthServiceService } from '../_Service/auth-service.service';
import { AlertifyService } from '../_Service/alertify.service';
import { VactionsService } from '../_Service/vactions.service';
import { Vaction } from '../_models/vaction';

@Component({
  selector: 'app-management-vactions',
  templateUrl: './management-vactions.component.html',
  styleUrls: ['./management-vactions.component.css']
})
export class ManagementVactionsComponent implements OnInit {
  model: any={};
  Vactions:Vaction[];
  users: string;

  constructor( private http:HttpClient,private auth:AuthServiceService, private alert:AlertifyService ,private vactionService:VactionsService) { }

  ngOnInit(): void {
    this.AllVactions();
  }
  login()
  {
  this.auth.login(this.model).subscribe(next=>{
 this.alert.success("logged in Successfuly");
 this.users=this.auth.name;
 
  },error=>
  {
  this.alert.error("failed to login");
  
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
    this.alert.message("logged out");
    
  }
 

Switch(){

  localStorage.removeItem("user");


}
AllVactions()
{
  this.vactionService.getAllVactions().subscribe((Vactions:Vaction[])=> 
{ this.Vactions=Vactions;},
 error=>{this.alert.error("error Vaction !!");});
    
}


}
