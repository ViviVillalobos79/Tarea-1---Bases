import { Component} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente2 } from 'src/app/models/cliente2';
import { Productor2 } from 'src/app/models/productor2';
import { ClientService } from '../../services/client.service';
import {ProductorServiceService} from '../../services/productor-service.service'

@Component({
  selector: 'vistacliente',
  templateUrl: './vistacliente.component.html',
  styleUrls: ['./vistacliente.component.css'],
  providers:[ClientService, ProductorServiceService],
})
export class VistaClienteComponent {
  tramos = ['Productor 1', 'Productor 2', 'Productor 3', 'Produ'];
  tramoes = []
  tramoesC = []
  i = 0;
  img = [
    '../../../assets/Images/Image1.png',
    '../../../assets/Images/Image2.png',
    '../../../assets/Images/Image5.png',
    '../../../assets/Images/Image6.png',
    '../../../assets/Images/Image30.png',
  ];
  productoresA:Productor2[];

  cliente:Cliente2;
  cedula:string;

  constructor(
    private _route: ActivatedRoute,
    protected clientSvc: ClientService,
    private productorService: ProductorServiceService,
    ) {
    console.log(this._route.snapshot.paramMap.get('id'));
    this.cedula = this._route.snapshot.paramMap.get('id');
    this.clientSvc.getClienteCedula(this.cedula).subscribe((res: Cliente2) => {
    this.cliente = res;
    console.log(this.cliente);
    this.getProductores(res);
    });
  }

  getProductores(cliente:Cliente2){
    console.log(this.cliente.direccion[0],
      this.cliente.direccion[1],
      this.cliente.direccion[2]);
    this.productorService.getProducDireccion(
      cliente.direccion[0],
      cliente.direccion[1],
      cliente.direccion[2]).subscribe((res: Productor2[]) => {
        this.productoresA = res;
        console.log(this.productoresA);
        this.setTramos(res);
      });
  }


  setTramos(productores:Productor2[]){
    productores.forEach(element => {
      this.tramoes.push(element.usuario);
    });
  }

  left() {
    if (this.i > 0) {
      this.i = this.i - 1;
    }
  }

  right() {
    if (this.i < 4) {
      this.i = this.i + 1;
    }
  }
}

