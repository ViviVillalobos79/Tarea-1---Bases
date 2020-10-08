import {Component} from '@angular/core'

@Component({
    selector: 'adminafiliados',
    templateUrl: './adminafiliados.component.html',
    styleUrls: ['./adminafiliados.component.css']
})

export class AdminAfiliados{
    public Nombre: string;
    public Apellidos: string;
    public Cedula: number;
    public Direccion: string;
    public FecNac: string;
    public Telefono: number;
    public Sinpe: number;
    public LgsEntre: string;

    constructor(){
        this.Nombre = "Pablo";
        this.Apellidos = "Azofeifa González";
        this.Cedula = 2661515;
        this.Direccion = "Guapiles, Limón";
        this.FecNac = "25/10/90";
        this.Telefono = 1351112;
        this.Sinpe = 1513215;
        this.LgsEntre = "La Rita";

    }
}