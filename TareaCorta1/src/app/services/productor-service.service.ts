import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Producto2 } from '../models/producto2';
import { Productor2 } from '../models/productor2';
import { User} from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class ProductorServiceService {

  private productoresUrl = '/api/Productor';
  private productoresAddUrl = '/api/Productor/agregar';

  constructor(private http:HttpClient) { }

  getProductores(){
    return this.http.get<Productor2[]>(this.productoresUrl);
  }

  addProdutor(productor:Productor2){
    return this.http.post<Productor2>( this.productoresAddUrl, productor);
  }

  authProductor(username:string, password:string){
    const url = '/api/Productor/Usuario/'+ username + '/' +password;
    return this.http.get<User>(url);
  }

  getProducDireccion(provincia:string, canton:string, distrito:string){
    const url = '/api/Productor/Direccion/'+provincia+'/'+canton+'/'+distrito;
    return this.http.get<Productor2[]>(url);
  }

  getProducCedula(cedula:string){
    const url = '/api/Productor/Cedula/'+cedula;
    return this.http.get<Productor2>(url);
  }

  getProducUsuario(usuario:string){
    const url = '/api/Productor/Usuario/'+usuario;
    return this.http.get<Productor2>(url);
  }

  getProductos(usuario:string){
    const url = '/api/Productor/Productos/'+usuario;
    return this.http.get<Producto2[]>(url);
  }

}
