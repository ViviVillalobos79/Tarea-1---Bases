import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria, Clientes, Direccion, Nombre_Persona, Productores } from './clientes';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

/**
 * Servicio API para la tabla Clientes
 */
export class ClientesService {

  // Url para acceder a la tabla en mongodb
  private clientesUrl = 'http://localhost:1050/api/Clientes/';  

  constructor( private http: HttpClient) { }

  // Peticion a la base de todos los clientes (get)
  getClientes (): Observable<Clientes[]> {
    return this.http.get<Clientes[]>(this.clientesUrl)
  }

  // Peticion a la base de un cliente por medio de la cedula (get)
  getClienteID(id: string): Observable<Clientes> {
    const url = `${this.clientesUrl}/${id}`;
    return this.http.get<Clientes>(url);
  }

  //Petición a la base para añadir un cliente (post)
  addCliente (clientes: Clientes): Observable<Clientes> {
    return this.http.post<Clientes>(this.clientesUrl, clientes, httpOptions);
  }

  // Petición a la base para eliminar un cliente (post)
  deleteCliente (clientes: Clientes | string): Observable<Clientes> {
    const id = typeof clientes === 'string' ? clientes : clientes.Cedula;
    const url = `${this.clientesUrl}/${id}`;
    return this.http.delete<Clientes>(url, httpOptions);
  }

  // Petición a la base para actualizar un cliente 
  updateCliente (clientes: Clientes): Observable<any> {
    return this.http.put(this.clientesUrl, clientes, httpOptions);
  }
}

export class CategoriaService{

  //Url para acceder a las categorias
  private categoriaUrl = 'http://localhost:1050/api/Categoria/';  

  constructor( private http: HttpClient) { }

  // Petición a la base de todas las categorias (get)
  getCategoria (): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.categoriaUrl)
  }
  
  //Petición a la base por una categoria por medio del idcategoria(get)
  getCategoriaID(id: string): Observable<Categoria> {
    const url = `${this.categoriaUrl}/${id}`;
    return this.http.get<Categoria>(url);
  }

  //Añadir una categoria (post)
  addCategoria (categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this.categoriaUrl, categoria, httpOptions);
  }
  
  // Eliminar una categoria (post)
  deleteCategoria (categoria: Categoria | string): Observable<Categoria> {
    const id = typeof categoria === 'string' ? categoria : categoria.IdCategoria;
    const url = `${this.categoriaUrl}/${id}`;
    return this.http.delete<Categoria>(url, httpOptions);
  }
  
  // Actualizar cualquier dato de un productor (post)
  updateCategoria (categoria: Categoria): Observable<any> {
    return this.http.put(this.categoriaUrl, categoria, httpOptions);
  }
}

export class DireccionService{

 // Url para acceder a la tabla en mongodb
 private direccionUrl = 'http://localhost:1050/api/Direccion/';  

 constructor( private http: HttpClient) { }

 
 getDireccion (): Observable<Direccion[]> {
   return this.http.get<Direccion[]>(this.direccionUrl)
 }

 
 getDireccionProvincia(id: string): Observable<Direccion> {
   const url = `${this.direccionUrl}/${id}`;
   return this.http.get<Direccion>(url);
 }

 getDireccionCanton(id: string): Observable<Direccion> {
  const url = `${this.direccionUrl}/${id}`;
  return this.http.get<Direccion>(url);
}

getDireccionDistrito(id: string): Observable<Direccion> {
  const url = `${this.direccionUrl}/${id}`;
  return this.http.get<Direccion>(url);
}

 
 addDireccion (direccion: Direccion): Observable<Direccion> {
   return this.http.post<Direccion>(this.direccionUrl, direccion, httpOptions);
 }

 
 deleteDireccion (direccion: Direccion | string): Observable<Direccion> {
   const id = typeof direccion === 'string' ? direccion : direccion.Provincia;
   const url = `${this.direccionUrl}/${id}`;
   return this.http.delete<Direccion>(url, httpOptions);
 }

 
 updateDireccion (direccion: Direccion): Observable<any> {
   return this.http.put(this.direccionUrl, direccion, httpOptions);
 }
}

export class Nombre_PersonaService{
  // Url para acceder a la tabla en mongodb
  private nombresUrl = 'http://localhost:1050/api/';  

  constructor( private http: HttpClient) { }

  // Peticion a la base de todos los clientes (get)
  getNombre (): Observable<Nombre_Persona[]> {
    return this.http.get<Nombre_Persona[]>(this.nombresUrl)
  }

  //Petición a la base para añadir un cliente (post)
  addNombre (nombre: Nombre_Persona): Observable<Nombre_Persona> {
    return this.http.post<Nombre_Persona>(this.nombresUrl, nombre, httpOptions);
  }

  // Petición a la base para eliminar un cliente (post)
  deleteNombre(nombre: Nombre_Persona | string): Observable<Nombre_Persona> {
    const id = typeof nombre === 'string' ? nombre : nombre;
    const url = `${this.nombresUrl}/${id}`;
    return this.http.delete<Nombre_Persona>(url, httpOptions);
  }

  // Petición a la base para actualizar un cliente 
  updateNombre (nombre: Nombre_Persona): Observable<any> {
    return this.http.put(this.nombresUrl, nombre, httpOptions);
  }
}

export class Pedido{
 
  private pedidosUrl = 'http://localhost:1050/api/Pedidos/';  

  constructor( private http: HttpClient) { }

  getPedidos (): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(this.pedidosUrl)
  }

  
  getPedidoNum(id: string): Observable<Pedido> {
    const url = `${this.pedidosUrl}/${id}`;
    return this.http.get<Pedido>(url);
  }

  
  addPedido (pedido: Pedido): Observable<Pedido> {
    return this.http.post<Pedido>(this.pedidosUrl, pedido, httpOptions);
  }

  deletePedido (pedido: Pedido | string): Observable<Pedido> {
    const id = typeof pedido === 'string' ? pedido : pedido;
    const url = `${this.pedidosUrl}/${id}`;
    return this.http.delete<Pedido>(url, httpOptions);
  }

 
  updatePedido (pedido: Pedido): Observable<any> {
    return this.http.put(this.pedidosUrl, pedido, httpOptions);
  }
}

export class Producto{

    
    private productoUrl = 'http://localhost:1050/api/Clientes/';  

    constructor( private http: HttpClient) { }
  
    
    getProducto (): Observable<Producto[]> {
      return this.http.get<Producto[]>(this.productoUrl)
    }

    getProductoNum(id: number): Observable<Producto> {
      const url = `${this.productoUrl}/${id}`;
      return this.http.get<Producto>(url);
    }
  
    
    addProducto (producto: Producto): Observable<Producto> {
      return this.http.post<Producto>(this.productoUrl, producto, httpOptions);
    }
  
  
    deleteProducto (producto: Producto | number): Observable<Producto> {
      const id = typeof producto === 'number' ? producto : producto;
      const url = `${this.productoUrl}/${id}`;
      return this.http.delete<Producto>(url, httpOptions);
    }
   
    updateCliente (producto: Producto): Observable<any> {
      return this.http.put(this.productoUrl, producto, httpOptions);
    }
}

export class ProductorService{

  //Url para acceder a los productores
  private productorUrl = 'http://localhost:1050/api/Productores/';  

  constructor( private http: HttpClient) { }

  // Petición a la base de todos los productores (get)
  getProductores (): Observable<Productores[]> {
    return this.http.get<Productores[]>(this.productorUrl)
  }
  
  //Petición a la base por un productor por medio de la cédula (get)
  getProductoresID(id: string): Observable<Productores> {
    const url = `${this.productorUrl}/${id}`;
    return this.http.get<Productores>(url);
  }

  // Añadir un productor (post)
  addProductor (productor: Productores): Observable<Productores> {
    return this.http.post<Productores>(this.productorUrl, productor, httpOptions);
  }
  
  // Eliminar un productor (post)
  deleteProductor (productor: Productores | number): Observable<Productores> {
    const id = typeof productor === 'number' ? productor : productor.Cedula;
    const url = `${this.productorUrl}/${id}`;
    return this.http.delete<Productores>(url, httpOptions);
  }
  
  // Actualizar cualquier dato de un productor (Post)
  updateProductor (productor: Productores): Observable<any> {
    return this.http.put(this.productorUrl, productor, httpOptions);
  }

}
