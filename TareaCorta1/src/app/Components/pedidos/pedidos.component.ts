import {Component} from '@angular/core'

@Component({
    selector: 'pedidos',
    templateUrl: './pedidos.component.html',
    styleUrls: ['./pedidos.component.css']
})

export class Pedidos{
    
    public Comprobante: string;
    public Direccion: string;

    productos = [{"Producto":"Papa","Cantida":"1"},{"Producto":"Yuca","Cantida":"2"},{"Producto":"Melon","Cantida":"3"},
    {"Producto":"Papaya","Cantida":"4"},{"Producto":"Platano","Cantida":"5"}]

    constructor(){
        this.Comprobante = "Hola";
        this.Direccion = "Costa Rica";
    }
}