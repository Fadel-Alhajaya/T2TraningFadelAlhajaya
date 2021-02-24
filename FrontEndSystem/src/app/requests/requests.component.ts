import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VactionsService } from '../_Service/vactions.service';
import { AlertifyService } from '../_Service/alertify.service';
import { Vaction } from '../_models/vaction';
import { error } from '@angular/compiler/src/util';
import { AuthServiceService } from '../_Service/auth-service.service';
import { NgIf } from '@angular/common';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
  
Vactions:Vaction[];
VactionAdd: any ={ empID :localStorage.getItem("user")};
  users: string;
  model: any={};
 

  constructor(private http:HttpClient, public vactionsService:VactionsService , private alert:AlertifyService, private auth:AuthServiceService) { }

  ngOnInit(): void {
    this.VactionsGet();
   
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
  
  VactionsGet()
  {
this.vactionsService.getSingelVactions(+this.auth.id ).subscribe((Vactions:Vaction[])=> 
{ this.Vactions=Vactions;},
 error=>{this.alert.error("You don't have any Vaction !!");});
  }
  
  addvaction()
  {
    return this.vactionsService.addVactions(this.VactionAdd).subscribe(() =>{

      this.alert.success("Vaction added Successfuly");  
      this.VactionsGet();
    },error=>{
      this.alert.error("Failed to Add Vaction");
      console.log(this.VactionAdd);
      
      this.VactionsGet();
    });
  }


}
