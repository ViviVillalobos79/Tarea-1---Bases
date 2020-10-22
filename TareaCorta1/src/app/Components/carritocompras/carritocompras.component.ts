import {Component} from '@angular/core'

@Component({
    selector: 'carritocompras',
    templateUrl: './carritocompras.component.html',
    styleUrls: ['./carritocompras.component.css']
})

export class CarritoCompras{
    feedbackProductor: string;
    feedbackProducto: string;
    constructor(){}

    compras = [{"Producto":"Maíz","Cantidad":1,"Precio":13,"PrecioBase":13,"id":0},
                {"Producto":"Papa","Cantidad":2,"Precio":12,"PrecioBase":12,"id":1},
                {"Producto":"Pepino","Cantidad":1,"Precio":23,"PrecioBase":23,"id":2},
                {"Producto":"Pimentón","Cantidad":1,"Precio":21,"PrecioBase":21,"id":3},
                {"Producto":"Tomate","Cantidad":1,"Precio":31,"PrecioBase":31,"id":4}]
    
    i=0;
    suma(id){
        this.compras[id].Cantidad=this.compras[id].Cantidad+1;
        this.compras[id].Precio=this.compras[id].Cantidad*this.compras[id].PrecioBase;
    }
    
    resta(id){
        this.compras[id].Cantidad=this.compras[id].Cantidad-1;
        this.compras[id].Precio=this.compras[id].Precio-this.compras[this.i].PrecioBase;
    }
   

    
}
