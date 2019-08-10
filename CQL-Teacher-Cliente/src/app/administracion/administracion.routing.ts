import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component'
import { ModoEdicionComponent } from './modo-edicion/modo-edicion.component'

const routes: Routes = [
    { path: 'SQL-Teacher/administracion/login', component: LoginComponent },
    { path: 'SQL-Teacher/administracion/modoEdicion', component: ModoEdicionComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class AdministracionRoutingModule { }