import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente2 } from 'src/app/models/cliente2';
import { Producto2 } from 'src/app/models/producto2';
import { Productor2 } from 'src/app/models/productor2';
import { ClientService } from '../../services/client.service';
import { ProductorServiceService } from '../../services/productor-service.service';

@Component({
  selector: 'tramoproductor',
  templateUrl: './tramoproductor.component.html',
  styleUrls: ['./tramoproductor.component.css'],
  providers: [ClientService, ProductorServiceService],
})
export class TramoProductor {
  usuarioPro: string;
  cedulaClie: string;

  productor: Productor2;
  cliente: Cliente2;

  nombreProductor: string;

  productosA:Producto2[];

  productos = [
    { Producto: 'Maíz', Cantidad: '123', Precio: '123' },
    { Producto: 'Papa', Cantidad: '123', Precio: '123' },
    { Producto: 'Pepino', Cantidad: '123', Precio: '123' },
    { Producto: 'Pimentón', Cantidad: '123', Precio: '123' },
    { Producto: 'Tomate', Cantidad: '123', Precio: '123' },
  ];

  constructor(
    private _route: ActivatedRoute,
    protected clientSvc: ClientService,
    private productorService: ProductorServiceService
  ) {
    console.log(this._route.snapshot.paramMap.get('id'));
    this.usuarioPro = this._route.snapshot.paramMap.get('id');

    console.log(this._route.snapshot.paramMap.get('cedula'));
    this.cedulaClie = this._route.snapshot.paramMap.get('cedula');

    this.productorService
      .getProducUsuario(this.usuarioPro)
      .subscribe((res: Productor2) => {
        this.productor = res;
      });
    this.clientSvc.getClienteCedula(this.cedulaClie).subscribe((res: Cliente2) => {
      this.cliente = res;
    });

    this.productorService.getProductos(this.usuarioPro).subscribe((res: Producto2[]) => {
      this.productosA = res;
      this.setInfoProductor(this.productosA);
    });
  }

  setInfoProductor(prods:Producto2[]){
    prods.forEach(producto => {
      var pro = {Producto: producto.nombre, Cantidad: producto.cantidad, Precio: producto.precio};
      this.productos.push(pro);
    });

  }
}
