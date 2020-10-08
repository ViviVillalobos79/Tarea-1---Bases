import {Component} from '@angular/core'

@Component({
    selector: 'reportes',
    templateUrl: './reportes.component.html',
    styleUrls: ['./reportes.component.css']
})

export class Reportes{
    productos = [{"Producto":"Papa"},{"Producto":"Yuca"},{"Producto":"Melon"},{"Producto":"Papaya"},{"Producto":"Platano"}]

    cliente = [{"Producto":"Papa"},{"Producto":"Yuca"},{"Producto":"Melon"},{"Producto":"Papaya"},{"Producto":"Platano"}]
}