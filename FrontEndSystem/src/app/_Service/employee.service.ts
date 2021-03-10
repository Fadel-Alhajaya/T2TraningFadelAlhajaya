import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Employee } from '../_models/employee';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthServiceService } from './auth-service.service';

const httpOptions = {
  headers:new HttpHeaders({
    'Authorization':'Bearer '+localStorage.getItem("token")
  })
  };
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url=environment.baseUrl;
  constructor(  private http:HttpClient ,private auth:AuthServiceService) { }

  getAllEmployee():Observable<Employee[]>
  {
 return this.http.get<Employee[]>(this.url+"EmployeeAuth/getEmployee",httpOptions);
}
getSingelEmployee(id ):Observable<Employee[]>
  {
 return this.http.get<Employee[]>(this.url+"EmployeeAuth/GetSingelEmployee"+id,httpOptions);
}

}
