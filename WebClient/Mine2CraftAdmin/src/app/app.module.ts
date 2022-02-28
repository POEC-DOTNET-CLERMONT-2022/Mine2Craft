import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FurnaceManagementComponent } from './pages/furnace-management/furnace-management.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import {HttpClientModule} from "@angular/common/http";
import {ReactiveFormsModule} from "@angular/forms";
import { AuthModule } from '@auth0/auth0-angular';
import { HomeComponent } from './pages/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    FurnaceManagementComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
      domain: 'mine2craftcompany.eu.auth0.com',
      clientId: 'JrBTJ7fW4muhpWgXVIz5jrAtSrPXks3o'
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
