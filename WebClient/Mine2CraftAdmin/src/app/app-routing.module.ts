import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import {FurnaceManagementComponent} from "./pages/furnace-management/furnace-management.component";
import {HomeComponent} from "./pages/home/home.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'furnace', component: FurnaceManagementComponent, canActivate : [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
