import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  baseUrl=environment.baseUrl; 
  name:any;
  loggedin:boolean=false;
  id:any;

  constructor( private http:HttpClient) {
    
    
  }
  login(model:any)
  {
return this.http.post(this.baseUrl+"EmployeeAuth/employeeLogin" ,model).pipe(
  map((response:any)=>
  {
    const user=response;
    if(user)
    {localStorage.setItem("user",user.id);
    this.name=user.username;
   this.id=user.id;
    this.loggedin=true;
  }
  }
  ) );
  }
  register(model:any)
  {
return this.http.post(this.baseUrl+"EmployeeAuth/register",model);
this.loggedin=true;

  }
  Mangerlogin(model:any)
  {
return this.http.post(this.baseUrl+"MangerAuth/MangerLogin" ,model).pipe(
  map((response:any)=>
  {
    const user=response;
    if(user)
    {localStorage.setItem("user",user.id);
    this.name=user.username;
   this.id=user.id;
    this.loggedin=true;
  }
  }
  ) );

  }
  MangerRegister(model:any)
  {
return this.http.post(this.baseUrl+"MangerAuth/MangerRegister",model);
this.loggedin=true;

  }
}
