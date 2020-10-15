import {Component, OnInit} from '@angular/core'
import {Clientes} from '../../clientes'
import {ClientesService} from '../../clientes.service'
import {Location} from '@angular/common'
@Component({
    selector: 'gestionprodsclientes',
    templateUrl: './gestionprodsclientes.component.html',
    styleUrls: ['./gestionprodsclientes.component.css'],
    providers:[ClientesService]
})

export class GestionProdsClientes implements OnInit{
    
    public Nombre: string;
    public Apellidos: string;
    public Cedula: number;
    public Direccion: string;
    public FecNac: string;
    public Telefono: number;
    public Sinpe: number;
    public LgsEntre: string;
    public Usuario: string;
    public Password: string;
    public Categoria1: string;
    public Categoria2: string;
    
    clientes: Clientes[];
    constructor(private clientesService: ClientesService,
        private location: Location){
        this.Nombre = "Pablo";
        this.Apellidos = "Azofeifa González";
        this.Cedula = 2661515;
        this.Direccion = "Guapiles, Limón";
        this.FecNac = "25/10/90";
        this.Telefono = 1351112;
        this.Sinpe = 1513215;
        this.LgsEntre = "La Rita";
        this.Usuario = "Hola";
        this.Password = "12345";
        this.Categoria1 = "Productor"
        this.Categoria2 = "Cliente"
    }

    ngOnInit(): void {
        //this.clientesService.getClientes();
        this.clientesService.getClienteID("815935934").subscribe(res => {
      console.log('Res ', res);});
        this.getClientes();
     }
     goBack(): void {
        this.location.back();
      }
     
     getClientes(){
         //this.Nombre = Clientes.arguments
         return this.clientesService.getClientes()
         .subscribe(clientes => 
            {console.log(clientes); 
            this.clientes = clientes});
     }

     
}