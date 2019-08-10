import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { ModoEdicionComponent } from './modo-edicion/modo-edicion.component';

import { AdministracionRoutingModule } from './administracion.routing'

@NgModule({
  declarations: [LoginComponent, ModoEdicionComponent],
  imports: [
    CommonModule,
    AdministracionRoutingModule
  ]
})
export class AdministracionModule { }
