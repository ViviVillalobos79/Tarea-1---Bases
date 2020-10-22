import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Client } from '../models/client';
import { Cliente2 } from '../models/cliente2';
import { User } from '../models/user';
import { Pedido2 } from '../models/pedido2';
import { Categoria2 } from '../models/categoria2';

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

  authCliente(username:string, password:string){
    const url = '/api/Client/Usuario/'+ username + '/' +password;
    return this.http.get<User>(url);
  }

  getClienteCedula(cedula:string){
    const url = '/api/Client/Cedula/'+cedula;
    return this.http.get<Cliente2>(url);
  }

  addPedido(pedido:Pedido2){
    const url = '/api/Client/agregarPedido';
    return this.http.post<Pedido2>(url, pedido);
  }

  addCategoria(categoria:Categoria2){
    const url = '/api/Client/agregarCategoria';
    return this.http.post<Categoria2>(url, categoria);
  }

}
