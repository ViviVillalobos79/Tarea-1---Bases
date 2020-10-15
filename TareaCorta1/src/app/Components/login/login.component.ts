import {Component} from '@angular/core'
import { DataService } from '../../data.service';
import { FormControl } from '@angular/forms';
import { Clientes } from 'src/app/clientes';
import { Observable } from 'rxjs';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers:[DataService],
})

export class Login{
    
  name = new FormControl('');
  pass = new FormControl('');

  //Consigue los usuarios válidos para el login del REST
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
      if(user.toString() == user1.toString() && pw.toString() == pw1.toString()){
        login = true;
        break;
      }
    }
    if(login){
      //Poner código de que pasa cuando hace login
      console.log("hace login");
    }
    else{
      //Poner código de que pasa cuando hace login
      console.log("no lo hace")
    }
  }

    
}