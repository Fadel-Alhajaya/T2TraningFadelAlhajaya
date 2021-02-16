import { Router, RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RequestsComponent } from './requests/requests.component';
import { EmployeesComponent } from './employees/employees.component';
import { AuthGuard } from './_guards/auth.guard';

export const routes: Routes = [
    { path: '', component: NavComponent },
    { path: 'home', component: HomeComponent },
    { path: 'requests', component: RequestsComponent,canActivate:[AuthGuard]},
    {path:'employee',component:EmployeesComponent ,canActivate:[AuthGuard]},
    {path: '**', redirectTo: 'home',pathMatch:"full" }, 
  
];