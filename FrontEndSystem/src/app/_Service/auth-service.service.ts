import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  baseUrl="https://localhost:5001/api/EmployeeAuth/employeeLogin";

  constructor( private http:HttpClient) {
    
    
  }
  login(model:any)
  {
return this.http.post(this.baseUrl ,model).pipe(
  map((response:any)=>
  {
    const user=response;
    if(user)
    {localStorage.setItem("user",user);
  }
  }
  ) );
  }
}
