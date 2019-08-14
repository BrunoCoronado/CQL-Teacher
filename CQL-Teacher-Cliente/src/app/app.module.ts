import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AdministracionModule } from './administracion/administracion.module'
import { EdicionModule } from './edicion/edicion.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AdministracionModule,
    EdicionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
