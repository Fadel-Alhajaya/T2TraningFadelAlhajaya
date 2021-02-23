import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Vaction } from '../_models/vaction';
import { Observable } from 'rxjs';

const httpOptions = {
headers:new HttpHeaders({
  'Authorization':'Bearer '+localStorage.getItem('user')
})
};
@Injectable({
  providedIn: 'root'
})
export class VactionsService {
 url=environment.baseUrl;
 

  constructor(private http:HttpClient) { 

  }

  getAllVactions( ):Observable<Vaction[]>{
 return  this.http.get<Vaction[]>(this.url +"VacationsRequests/allvaction",httpOptions);
  }
  getSingelVactions( id):Observable<Vaction[]>{
    return  this.http.get<Vaction[]>(this.url +"VacationsRequests/"+id ,httpOptions);
     }
   
     addVactions(vaction:any)
     {

      return this.http.post(this.url+"VacationsRequests/add_vactions",vaction);
     }

}
