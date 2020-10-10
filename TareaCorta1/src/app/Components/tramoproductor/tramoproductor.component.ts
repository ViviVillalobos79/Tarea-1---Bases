import {Component} from '@angular/core'

@Component({
    selector: 'tramoproductor',
    templateUrl: './tramoproductor.component.html',
    styleUrls: ['./tramoproductor.component.css']
})

export class TramoProductor{
    productos = [{"Producto":"Maíz","Cantidad":"123","Precio":"123"},
                {"Producto":"Papa","Cantidad":"123","Precio":"123"},
                {"Producto":"Pepino","Cantidad":"123","Precio":"123"},
                {"Producto":"Pimentón","Cantidad":"123","Precio":"123"},
                {"Producto":"Tomate","Cantidad":"123","Precio":"123"}]

}
               