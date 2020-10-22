import {Component} from '@angular/core'
import { Producto2 } from 'src/app/models/producto2';
import { ClientService } from '../../services/client.service';
import { ProductorServiceService } from '../../services/productor-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Productor2 } from 'src/app/models/productor2';
import { Cliente2 } from 'src/app/models/cliente2';
import { Pedido2 } from 'src/app/models/pedido2';

@Component({
    selector: 'carritocompras',
    templateUrl: './carritocompras.component.html',
    styleUrls: ['./carritocompras.component.css'],
    providers: [ClientService, ProductorServiceService],
})

export class CarritoCompras{
    feedbackProductor: string;
    feedbackProducto: string;

    usuarioPro: string;
    cedulaClie: string;

    productor: Productor2;
    cliente: Cliente2;

    productosA:Producto2[];

    constructor(
      private _route: ActivatedRoute,
      protected clientSvc: ClientService,
      private productorService: ProductorServiceService,
      private router: Router
    ){
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

    compras = [{"Producto":"Maíz","Cantidad":1,"Precio":13,"PrecioBase":13,"id":0},
                {"Producto":"Papa","Cantidad":2,"Precio":12,"PrecioBase":12,"id":1},
                {"Producto":"Pepino","Cantidad":1,"Precio":23,"PrecioBase":23,"id":2},
                {"Producto":"Pimentón","Cantidad":1,"Precio":21,"PrecioBase":21,"id":3},
                {"Producto":"Tomate","Cantidad":1,"Precio":31,"PrecioBase":31,"id":4}];

    i=0;
    suma(id){
        this.compras[id].Cantidad=this.compras[id].Cantidad+1;
        this.compras[id].Precio=this.compras[id].Cantidad*this.compras[id].PrecioBase;
    }

    resta(id){
        this.compras[id].Cantidad=this.compras[id].Cantidad-1;
        this.compras[id].Precio=this.compras[id].Precio-this.compras[this.i].PrecioBase;
    }

    setInfoProductor(prods:Producto2[]){
      prods.forEach(producto => {
        var pro = {"Producto": producto.nombre, "Cantidad": 0, "Precio": 0,"PrecioBase":+(producto.precio),"id":+(producto.numproducto)};
        this.compras.push(pro);
      });

    }

    saveData(){
      this.generatePedido();
      this.router.navigate(['/comprobante',this.cedulaClie]);

    }

    generatePedido(){
      var monto = 0;
      var productos =[];
      var cantproductos = [];
      this.compras.forEach(element => {
        monto = monto+element.Precio;
        productos.push(element.Producto);
        cantproductos.push(element.Cantidad.toString());
      });
      var pedido = new Pedido2();

      pedido.numpedido = Math.random().toString();
      pedido.monto = monto.toString();
      pedido.productos = productos;
      pedido.cantproductos = cantproductos;
      pedido.numcomprobante = Math.random().toString();
      pedido.cedulacliente = this.cedulaClie;
      pedido.entregado = false;

      this.clientSvc.addPedido(pedido).subscribe((res: Pedido2) => {
        console.log(res);
      });
    }



}
