import { Router, RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { RequestsComponent } from './requests/requests.component';
import { EmployeesComponent } from './employees/employees.component';
import { AuthGuard } from './_guards/auth.guard';
import { MangeComponent } from './mange/mange.component';
import { RegisterComponent } from './register/register.component';

export const routes: Routes = [
    //{ path: '', component: NavComponent,pathMatch:"full"  },
    { path: 'manage', component: MangeComponent ,pathMatch:"full" },
    { path: 'requests', component: RequestsComponent,canActivate:[AuthGuard]},
    {path:'employee',component:EmployeesComponent ,canActivate:[AuthGuard]},
    {path:'register',component:RegisterComponent,pathMatch:"full" },
   {path: '**', redirectTo: 'nav',pathMatch:"full" }, 
   
  
];