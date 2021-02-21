import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VactionsService } from '../_Service/vactions.service';
import { AlertifyService } from '../_Service/alertify.service';
import { Vaction } from '../_models/vaction';
import { error } from '@angular/compiler/src/util';
import { AuthServiceService } from '../_Service/auth-service.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
Vactions:Vaction[];
  constructor(private http:HttpClient, private vactionsService:VactionsService , private alert:AlertifyService, private auth:AuthServiceService) { }

  ngOnInit(): void {
    this.VactionsGet();
  }
  
  VactionsGet()
  {
this.vactionsService.getSingelVactions(+this.auth.id ).subscribe((Vactions:Vaction[])=> { this.Vactions=Vactions;
},
 error=>{this.alert.error(error);});
  }


}
