import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  baseUrl=environment.baseUrl; 
  name:any;
  loggedin:boolean=false;
  id:any;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  mangerToken:any

  constructor( private http:HttpClient) {
    
    
  }
  login(model:any)
  {
return this.http.post(this.baseUrl+"EmployeeAuth/employeeLogin" ,model).pipe(
  map((response:any)=>
  {
    const user=response;
    if(user)
    {localStorage.setItem("token",user.token);
    this.decodedToken = this.jwtHelper.decodeToken(user.token);
    console.log(this.decodedToken);
    this.name=user.username;
   this.id=user.id;
    this.loggedin=true;
  }
  }
  ) );
  }
  /////////if he logged in
  loggedIn()
  {
  const token=localStorage.getItem("token");
    return ! this.jwtHelper.isTokenExpired(token);
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
    {localStorage.setItem("token",user.token);
    this.mangerToken = this.jwtHelper.decodeToken(user.token);
    console.log(this.mangerToken);
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
