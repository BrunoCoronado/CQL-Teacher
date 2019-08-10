import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import { LoginComponent } from './login/login.component'
import { EditorPrincipianteComponent } from './editor-principiante/editor-principiante.component'
import { EditorIntermedioComponent } from './editor-intermedio/editor-intermedio.component'
import { EditorAvanzadoComponent } from './editor-avanzado/editor-avanzado.component'

const routes: Routes = [
    { path: 'SQL-Teacher/editor/principiante', component: EditorPrincipianteComponent },
    { path: 'SQL-Teacher/editor/intermedio', component: EditorIntermedioComponent },
    { path: 'SQL-Teacher/editor/avanzado', component: EditorAvanzadoComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class EdicionRoutingModule { }