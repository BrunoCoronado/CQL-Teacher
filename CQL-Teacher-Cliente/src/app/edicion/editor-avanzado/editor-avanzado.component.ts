import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-editor-avanzado',
  templateUrl: './editor-avanzado.component.html',
  styleUrls: ['./editor-avanzado.component.css']
})
export class EditorAvanzadoComponent implements OnInit {

  contenido: string;

  constructor() { }

  ngOnInit() {
  }

  correrEntrada(){
    console.log(this.contenido);
  }

}