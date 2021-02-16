import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthServiceService } from './_Service/auth-service.service';
import { AlertifyService } from './_Service/alertify.service';
import { RequestsComponent } from './requests/requests.component';
import { EmployeesComponent } from './employees/employees.component';
import { routes } from './routes';
import { AuthGuard } from './_guards/auth.guard';


@NgModule({
  declarations: [
    AppComponent,

    LoginComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    RequestsComponent,
    EmployeesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    AuthServiceService,
   AlertifyService,
   AuthGuard

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
