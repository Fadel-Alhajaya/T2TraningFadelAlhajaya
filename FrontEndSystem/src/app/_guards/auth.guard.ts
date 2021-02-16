import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthServiceService } from '../_Service/auth-service.service';
import { AlertifyService } from '../_Service/alertify.service';



@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate{
  constructor(protected authService:AuthServiceService,private router:Router,private alertfy:AlertifyService)
  {


  }
  canActivate():  boolean  {

    if(this.authService.loggedin)
    {
      return true;

    }
    this.alertfy.error('You shall not pass !');
    this.router.navigate(['/home']);
    return false;

  }
 
}