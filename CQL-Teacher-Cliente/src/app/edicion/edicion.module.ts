import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelInformacionComponent } from './panel-informacion/panel-informacion.component';
import { PanelSalidaComponent } from './panel-salida/panel-salida.component';
import { EditorPrincipianteComponent } from './editor-principiante/editor-principiante.component';
import { EditorIntermedioComponent } from './editor-intermedio/editor-intermedio.component';
import { EditorAvanzadoComponent } from './editor-avanzado/editor-avanzado.component';

import { EdicionRoutingModule } from './edicion.routing';



@NgModule({
  declarations: [PanelInformacionComponent, PanelSalidaComponent, EditorPrincipianteComponent, EditorIntermedioComponent, EditorAvanzadoComponent],
  imports: [
    CommonModule,
    EdicionRoutingModule
  ]
})
export class EdicionModule { }
