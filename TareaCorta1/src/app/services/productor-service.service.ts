import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

}
