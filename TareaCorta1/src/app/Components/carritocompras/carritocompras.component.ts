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

    compras = [{"Producto":"Maíz","Cantidad":1,"Precio":13},
                {"Producto":"Papa","Cantidad":2,"Precio":12},
                {"Producto":"Pepino","Cantidad":1,"Precio":23},
                {"Producto":"Pimentón","Cantidad":1,"Precio":21},
                {"Producto":"Tomate","Cantidad":1,"Precio":31}]
    
    i=0;
    suma(prod){
        if(prod == this.compras[this.i].Producto){
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad+1;
            this.compras[this.i].Precio=this.compras[this.i].Precio+this.compras[this.i].Precio;
        }else if(prod == this.compras[this.i+1].Producto){
            this.i=this.i+1
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad+1;
            this.compras[this.i].Precio=this.compras[this.i].Precio+this.compras[this.i].Precio;
        }else if(prod == this.compras[this.i-1].Producto){
            this.i=this.i-1;
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad+1;
            this.compras[this.i].Precio=this.compras[this.i].Precio+this.compras[this.i].Precio;
        }
    }
    resta(prod){
        if(prod == this.compras[this.i].Producto){
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad-1;
            this.compras[this.i].Precio=this.compras[this.i].Precio-this.compras[this.i].Precio;
        }else if(prod == this.compras[this.i+1].Producto){
            this.i=this.i+1
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad-1;
            this.compras[this.i].Precio=this.compras[this.i].Precio-this.compras[this.i].Precio;
        }else if(prod == this.compras[this.i-1].Producto){
            this.i=this.i-1;
            this.compras[this.i].Cantidad=this.compras[this.i].Cantidad-1;
            this.compras[this.i].Precio=this.compras[this.i].Precio-this.compras[this.i].Precio;
        }
    }
   

    
}
