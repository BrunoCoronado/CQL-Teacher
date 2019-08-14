import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class EdicionService {

  constructor(private http: HttpClient) { }

  postConsulta(body){
    return this.http.post('http://localhost:53250/api/consulta', body);    
  }
}
