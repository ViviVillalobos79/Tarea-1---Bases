import {Component} from '@angular/core'

@Component({
    selector: 'vistapublico',
    templateUrl: './vistapublico.component.html',
    styleUrls: ['./vistapublico.component.css']
})

export class VistaPublico{
    public prueba: string;

    

    constructor(){
        this.prueba = "Prueba Funciona";
    }
    
}