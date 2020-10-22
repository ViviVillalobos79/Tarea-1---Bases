import {Component} from '@angular/core'
import { Categoria2 } from 'src/app/models/categoria2';
import { ClientService } from '../../services/client.service';

@Component({
    selector: 'gestioncategorias',
    templateUrl: './gestioncategorias.component.html',
    styleUrls: ['./gestioncategorias.component.css'],
    providers: [ClientService],

})

export class GestionCategorias{
  idcat: string;
  nombre:string;
  constructor(protected clientSvc: ClientService){}

  saveData(){
    let categoria = new Categoria2();
    categoria.idcategoria = this.idcat;
    categoria.nombre = this.nombre;
    this.clientSvc.addCategoria(categoria).subscribe((res: Categoria2) => {
      console.log(res);
    });
  }

  idSet(id: string) {
    this.idcat = id;
  }

  nombreSet(nombre: string) {
    this.nombre = nombre;
  }

}
