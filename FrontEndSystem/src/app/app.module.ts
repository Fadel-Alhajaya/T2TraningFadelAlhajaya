import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    RequestsComponent,
    EmployeesComponent,
    MangeComponent
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
   AuthGuard,
   VactionsService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
