import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  baseUrl="https://localhost:5001/api/EmployeeAuth/";

  constructor( private http:HttpClient) {
    
    
  }
  login(model:any)
  {
return this.http.post(this.baseUrl+"employeeLogin" ,model).pipe(
  map((response:any)=>
  {
    const user=response;
    if(user)
    {localStorage.setItem("user",user.username);
  }
  }
  ) );
  }
  register(model:any)
  {
return this.http.post(this.baseUrl+"register",model);

  }
}
