import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {FurnaceManagementComponent} from "./pages/furnace-management/furnace-management.component";
import {LoginComponent} from "./pages/login/login.component";
import {AuthGuard} from "./guards/auth.guard";

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'user', component: FurnaceManagementComponent, canActivate : [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
