import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { JwtModule } from "@auth0/angular-jwt";
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';




import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { RegisterComponent } from './register/register.component';
import { AuthServiceService } from './_Service/auth-service.service';
import { AlertifyService } from './_Service/alertify.service';
import { RequestsComponent } from './requests/requests.component';
import { EmployeesComponent } from './employees/employees.component';
import { routes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { MangeComponent } from './mange/mange.component';
import { VactionsService } from './_Service/vactions.service';
import { MangerRegisterComponent } from './manger-register/manger-register.component';
import { ManagementVactionsComponent } from './management-vactions/management-vactions.component';



@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    RequestsComponent,
    EmployeesComponent,
    MangeComponent,
    MangerRegisterComponent,
    ManagementVactionsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    JwtModule
  ],
  providers: [
    AuthServiceService,
   AlertifyService,
   AuthGuard,
   VactionsService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
