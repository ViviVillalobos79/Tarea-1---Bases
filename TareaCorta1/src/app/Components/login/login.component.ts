import {Component} from '@angular/core'
import { DataService } from '../../services/data.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers:[DataService],
})

export class Login{
    // FormControl es un elemento de control que permite el manejo de los datos ingresados por el usuario
  name = new FormControl('');
  pass = new FormControl('');

  //Consigue los usuarios válidos para el login del REST
  client;
  USERS_DATA = []
  clientesObservable : Observable<any[]>

  constructor(private dataSvc: DataService){
    this.clientesObservable = this.dataSvc.getClients();
    this.dataSvc.getClients().subscribe((res : any[])=>{
      this.USERS_DATA = res;
      console.log(this.USERS_DATA);
    })
  }
    

  validate() : void{
    var user = this.name.value;
    var pw = this.pass.value;
    var contador = this.USERS_DATA.length;
    var login = false;

    for (let i = 0; i < contador; i++){
      var user1 = this.USERS_DATA[i].Usuario
      var pw1 = this.USERS_DATA[i].pass
      if(user == user1 && pw == pw1){
        login = true;
        this.client = this.USERS_DATA[i]
        break;
      }
    }
    if(login){
      // Poner código de que pasa cuando hace login
      // El usuario que hizo login es client
      console.log('hace login');

    }
    else{
      //Poner código de que pasa cuando hace login
      console.log("no lo hace")
    }
  }

    
}