import {Component} from '@angular/core'
import { DataService } from '../../services/data.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ClientService } from '../../services/client.service';
import {ProductorServiceService} from '../../services/productor-service.service'
import { Router} from '@angular/router'
import { User } from 'src/app/models/user';
import { Productor2 } from 'src/app/models/productor2';
import { Cliente2 } from 'src/app/models/cliente2';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers:[DataService, ClientService, ProductorServiceService],
})

export class Login{
    // FormControl es un elemento de control que permite el manejo de los datos ingresados por el usuario
  name = new FormControl('');
  pass = new FormControl('');
  rolA:string;
  user:string;
  pw:string;

  usuario: User;

  //Consigue los usuarios válidos para el login del REST
  client;
  CLIENTES_DATA :Cliente2[];
  PRODUCTORES_DATA : Productor2[];
  clientesObservable : Observable<any[]>

  constructor(private dataSvc: DataService,
              protected clientSvc: ClientService,
              private productorService: ProductorServiceService,
              private router: Router,){
    // this.clientesObservable = this.dataSvc.getClients();
    // this.dataSvc.getClients().subscribe((res : any[])=>{
    //   this.USERS_DATA = res;
    //   console.log(this.USERS_DATA);
    // });
    this.productorService.getProductores().subscribe((res:Productor2[])=>{
      this.PRODUCTORES_DATA = res;
    });

    this.clientSvc.getClients().subscribe((res:Cliente2[])=>{
      this.CLIENTES_DATA = res;
    });
  }

  rolSet(rol){
    this.rolA = rol;
    //this.authCliente();
  }

  setUsername(usernames: string) {
    this.user = usernames;
  }

  passwordSet(password: string) {
    this.pw = password;
  }


  validate() : void{
    //[routerLink]="['/cliente','Viviana123']"
    if (this.rolA == "cliente"){
      this.clientSvc.authCliente(this.user, this.pw).subscribe((res: User) => {
        this.usuario = res;
        console.log(res);
        this.auth(this.usuario);
    });
    }
    if (this.rolA == "productor"){
      this.productorService.authProductor(this.user, this.pw).subscribe((res: User) => {
        this.usuario = res;
        console.log(res);
        this.auth(this.usuario);
    });
    }
  }

  auth(user: User){
    console.log(user)
    if(user.login && user.aceptado){
      console.log(user.rol);
       if(user.rol = "Cliente"){
         this.router.navigate(['cliente',user.cedula]);
      }
      if(user.rol = "Productor"){
        this.router.navigate(['productor',user.cedula]);
     }
   }
  }



}
