import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'gestionproductos',
  templateUrl: './gestionproductos.component.html',
  styleUrls: ['./gestionproductos.component.css'],
  providers: [DataService],
})
export class GestionProductos {
  /*public productos = [{"Nombre":"Papa","Categoria":"Verduras","Precio":"500","Venta":"kilo","Disponibilidad":"Agotado","Foto":"1223"},
    {"Nombre":"Papaya","Categoria":"Frutas","Precio":"450","Venta":"kilo","Disponibilidad":"Disponible","Foto":"124523"},
    {"Nombre":"Manzana Verde","Frutas":"Verduras","Precio":"500","Venta":"Unidad","Disponibilidad":"Agotado","Foto":"1298"}]*/
  public Nombre: string;
  public Categoria: string;
  public Precio: number;
  public Venta: string;
  public Disponibilidad: string;
  public Foto: string;

  cedula: string;

  constructor(private dataSvc: DataService, private _route: ActivatedRoute) {
    this.Nombre = 'Papa';
    this.Categoria = 'Verdura';
    this.Precio = 450;
    this.Venta = 'kilo';
    this.Disponibilidad = 'Disponible';
    this.Foto = 'http';

    console.log(this._route.snapshot.paramMap.get('id'));
    this.cedula = this._route.snapshot.paramMap.get('id');
  }
}
