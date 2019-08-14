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
    this.data.postConsulta({ contenido: this.contenido }).subscribe( data => {
      console.log(data)
      this.contenido = "";
    });
  }

}