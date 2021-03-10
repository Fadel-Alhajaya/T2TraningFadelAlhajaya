import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Vaction } from '../_models/vaction';
import { Observable } from 'rxjs';
import { AuthServiceService } from './auth-service.service';

const httpOptions = {
headers:new HttpHeaders({
  'Authorization':'Bearer '+localStorage.getItem('token')
})
};
@Injectable({
  providedIn: 'root'
})
export class VactionsService {
 url=environment.baseUrl;
 Empid:any;
 

  constructor(private http:HttpClient, private auth :AuthServiceService) { 

  }

  getAllVactions():Observable<Vaction[]>{
 return  this.http.get<Vaction[]>(this.url +"VacationsRequests/allvaction");
  }
  getSingelVactions( id):Observable<Vaction[]>{
    return  this.http.get<Vaction[]>(this.url +"VacationsRequests/"+id );
     }
   
     addVactions(vaction:any)
     {

      return this.http.post(this.url+"VacationsRequests/"+"add_vactions",vaction);
     }

}
