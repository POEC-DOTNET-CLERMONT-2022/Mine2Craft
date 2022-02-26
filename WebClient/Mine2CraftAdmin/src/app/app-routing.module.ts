import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import {FurnaceManagementComponent} from "./pages/furnace-management/furnace-management.component";
import {LoginComponent} from "./pages/login/login.component";

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'furnace', component: FurnaceManagementComponent, canActivate : [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
