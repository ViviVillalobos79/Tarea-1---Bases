import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Clientes } from './clientes';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  private clientesUrl = 'http://localhost:1050/CedulaCliente/2015023336/';  // URL to web api
  constructor( private http: HttpClient) { }

  getClientes (): Observable<Clientes[]> {
    return this.http.get<Clientes[]>(this.clientesUrl)
  }

  getClienteID(id: string): Observable<Clientes> {
    const url = `${this.clientesUrl}/${id}`;
    return this.http.get<Clientes>(url);
  }

  addCliente (clientes: Clientes): Observable<Clientes> {
    return this.http.post<Clientes>(this.clientesUrl, clientes, httpOptions);
  }

  deleteCliente (clientes: Clientes | string): Observable<Clientes> {
    const id = typeof clientes === 'string' ? clientes : clientes.Cedula;
    const url = `${this.clientesUrl}/${id}`;

    return this.http.delete<Clientes>(url, httpOptions);
  }

  updateCliente (clientes: Clientes): Observable<any> {
    return this.http.put(this.clientesUrl, clientes, httpOptions);
  }
}


