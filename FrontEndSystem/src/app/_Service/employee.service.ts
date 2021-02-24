import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Employee } from '../_models/employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url=environment.baseUrl;
  constructor(  private http:HttpClient) { }

  getAllEmployee():Observable<Employee[]>
  {
 return this.http.get<Employee[]>(this.url+"EmployeeAuth/getEmployee");
}

}
