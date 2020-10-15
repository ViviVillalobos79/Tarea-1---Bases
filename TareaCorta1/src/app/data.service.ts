import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Clientes } from './clientes';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private clientesUrl = '/api/CedulaCliente';  
  private usernameUrl = '/api/UsuarioCliente'; 
   
  constructor(private http:HttpClient) { }
  
  getAll(cedula: string):Observable<Clientes>{
    const url = `${this.clientesUrl}/${cedula}/`;
    return this.http.get<Clientes>(url);
  }

  getClientWUser(username: string):Observable<Clientes>{
    const url = `${this.usernameUrl}/${username}/`;
    return this.http.get<Clientes>(url);
  }

  getClients(){
    return this.http.get<any[]>('/api/All/clientes/');
  }

  
}
