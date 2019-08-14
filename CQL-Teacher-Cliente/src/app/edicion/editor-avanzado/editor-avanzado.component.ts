import { Component, OnInit } from '@angular/core';
import { EdicionService } from '../edicion.service';

@Component({
  selector: 'app-editor-avanzado',
  templateUrl: './editor-avanzado.component.html',
  styleUrls: ['./editor-avanzado.component.css']
})
export class EditorAvanzadoComponent implements OnInit {

  contenido: string;

  constructor(private data : EdicionService) { }

  ngOnInit() {
  }

  correrEntrada(){
    const paquete_lup = `
    [+QUERY]
      [+USER]
        user
      [-USER]
      [+DATA]
        ${ this.contenido }
      [-DATA]
    [-QUERY]`;

    const paquete_login = `
    [+LOGIN]
      [+USER]
        user
      [-USER]
      [+PASS]
        pass
      [-PASS]
    [-LOGIN]`;

    const paquete_logout = `
    [+LOGOUT]
      [+USER]
        user
      [-USER]
    [-LOGOUT]`;

    const paquete_struct = `
    [+STRUCT]
      [+USER]
        user
      [-USER]
    [-STRUCT]`;
    
    this.data.postConsulta({ contenido: paquete_struct }).subscribe( data => {
      console.log(data)
      this.contenido = "";
    });
  }

}