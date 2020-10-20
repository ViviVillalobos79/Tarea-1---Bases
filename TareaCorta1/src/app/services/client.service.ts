import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Client } from '../models/client';
import { Cliente2 } from '../models/cliente2';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private clientesUrl = '/api/Client';
  private clientesAddUrl = '/api/Clientes/agregar';
  private clientAddUrl = '/api/Client/agregar';

  constructor(private http:HttpClient) { }

  getClients(){
    return this.http.get<Cliente2[]>(this.clientesUrl);
  }

  addCliente(client:Client){
    return this.http.post<Client>(this.clientesAddUrl, client);
  }

  addClient(client:Cliente2){
    return this.http.post<Cliente2>( this.clientAddUrl, client);
  }

}
