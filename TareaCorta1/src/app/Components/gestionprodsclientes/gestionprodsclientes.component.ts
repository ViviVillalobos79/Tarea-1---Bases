import {Component, OnInit} from '@angular/core'
import {Location} from '@angular/common'
@Component({
    selector: 'gestionprodsclientes',
    templateUrl: './gestionprodsclientes.component.html',
    styleUrls: ['./gestionprodsclientes.component.css'],
    providers:[]
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

    ngOnInit(): void {
    //     //this.clientesService.getClientes();
    //     this.clientesService.getClienteID("815935934").subscribe(res => {
    //   console.log('Res ', res);});
    //     this.getClientes();
    }
    goBack(): void {
    //     this.location.back();
    }
     
    getClientes(){
    //      //this.Nombre = Clientes.arguments
    //      return this.clientesService.getClientes()
    //      .subscribe(clientes => 
    //         {console.log(clientes); 
    //         this.clientes = clientes});
    }

     
}