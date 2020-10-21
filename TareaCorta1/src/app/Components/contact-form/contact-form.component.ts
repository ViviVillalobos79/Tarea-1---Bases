import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ProvinciaI, CantonI, DistritoI } from '../../models/model.interface';
import { DatasService } from '../../services/datas.service';
import { DataService } from '../../services/data.service';
import { Observable } from 'rxjs';
import { Cliente2 } from '../../models/cliente2';
import { HttpClient } from '@angular/common/http';
import { ClientService } from '../../services/client.service';
import { Productor2 } from 'src/app/models/productor2';
import {ProductorServiceService} from '../../services/productor-service.service'
import { Router} from '@angular/router'


@Component({
  selector: 'contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css'],
  providers: [DatasService, DataService, ClientService, ProductorServiceService],
})
export class ContactFormComponent {
  public selectedProvincia: ProvinciaI = { id: 0, name: '' };
  public selectedProvinciaA: ProvinciaI = { id: 0, name: '' };
  public selectedCanton: CantonI = { id: 0, name: '', provinciaId: 0 };
  public selectedCantonA: CantonI = { id: 0, name: '', provinciaId: 0 };
  public selectedDistrito: DistritoI = { id: 0, name: '', cantonId: 0 };
  public selectedDistritoA: DistritoI = { id: 0, name: '', cantonId: 0 };
  public provincias: ProvinciaI[];
  public cantones: CantonI[];
  public distritos: DistritoI[];

  clientesObservable: Observable<any[]>;

  cedula = new FormControl('');
  myForm: FormGroup;
  nombre: string;
  apellido1: string;
  username: string;
  password: string;
  year: number;
  month: number;
  day: number;
  telefono: string;
  sinpe: string;
  apellido2: string;
  cedulaA: string;
  rolA:string;

  USERS_DATA = [];

  ngOnInit() {
    this.provincias = this.datasServices.getProvincias();
  }

  constructor(
    public fb: FormBuilder,
    protected clientSvc: ClientService,
    private datasServices: DatasService,
    private productorService: ProductorServiceService,
    private dataSvc: DataService,
    private http: HttpClient,
    private router: Router
  ) {
    this.myForm = this.fb.group({
      cedula: ['', [Validators.required]],
      usuario: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
        ],
      ],
      pass: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
        ],
      ],
      nombre: ['', [Validators.required]],
      apellido1: ['', [Validators.required]],
      apellido2: ['', [Validators.required]],
      provincia: ['', [Validators.required]],
      canton: ['', [Validators.required]],
      distrito: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      telefono: ['', [Validators.required]],
      sinpe: ['', [Validators.required]],
      rol: ['', [Validators.required]]
    });

    // this.clientSvc.getClients().subscribe((res : Cliente2[])=>{
    //   this.USERS_DATA = res;
    //   console.log(this.USERS_DATA);
    // });
  }

  cedula_check(x: number) {
    let ced_len = x.toString().length;
    return ced_len != 9;
  }

  generateClient(){
    let cliente2 = new Cliente2();

    cliente2.Cedula = this.cedulaA;
    cliente2.Usuario = this.username;
    cliente2.Nombre = [this.nombre, this.apellido1, this.apellido2];
    cliente2.direccion = [this.selectedProvinciaA.name,
                          this.selectedCantonA.name,
                          this.selectedDistritoA.name];
    cliente2.dob = [this.day, this.month, this.year];
    cliente2.telefono = this.telefono;
    cliente2.SINPE = this.sinpe;
    cliente2.pass = this.password;
    cliente2.aceptado = false;
    cliente2.pedidos = [];

    this.clientSvc.addClient(cliente2).subscribe((res: Cliente2) => {
      console.log(res);
    });
  }

  generateProductor(){
    let productor2 = new Productor2();

    productor2.Cedula = this.cedulaA;
    productor2.Usuario = this.username;
    productor2.Nombre = [this.nombre, this.apellido1, this.apellido2];
    productor2.direccion = [this.selectedProvinciaA.name,
                          this.selectedCantonA.name,
                          this.selectedDistritoA.name];
    productor2.dob = [this.day, this.month, this.year];
    productor2.telefono = this.telefono;
    productor2.SINPE = this.sinpe;
    productor2.pass = this.password;
    productor2.aceptado = false;
    productor2.pedidos = [];
    productor2.productos = [];

    this.productorService.addProdutor(productor2).subscribe((res: Productor2) => {
      console.log(res);
    });

  }

  saveData1() {
    if (this.rolA == "cliente"){
      this.generateClient();
    }
    if (this.rolA == "productor"){
      this.generateProductor();
    }
    this.router.navigate(['home']);
  }


  //Guarda la provincia
  onSelect(id: number): void {
    this.cantones = this.datasServices
      .getCantones()
      .filter((item: CantonI) => item.provinciaId == id);

    let provinciasTemp = this.datasServices
      .getProvincias()
      .filter((item: ProvinciaI) => item.id == id);
    provinciasTemp.forEach((element) => {
      if (element.id == id) {
        this.selectedProvinciaA = element;
      }
    });
  }

  //Guarda el cantón
  onSelect2(id: number): void {
    this.distritos = this.datasServices
      .getDistritos()
      .filter((item: DistritoI) => item.cantonId == id);

    let cantonesTemp = this.datasServices
      .getCantones()
      .filter((item: CantonI) => item.id == id);
    cantonesTemp.forEach((element) => {
      if (element.id == id) {
        this.selectedCantonA = element;
      }
    });
  }

  //Guarda el distrito
  onSelect3(id: number): void {
    let distritosTemmp: DistritoI[] = this.datasServices
      .getDistritos()
      .filter(
        (item: DistritoI) =>
          item.cantonId == this.selectedCanton.id && item.id == id
      );

    distritosTemmp.forEach((element) => {
      if (element.id == id && element.cantonId == this.selectedCanton.id) {
        this.selectedDistritoA = element;
      }
    });
    console.log(
      this.selectedProvinciaA.name,
      this.selectedCantonA.name,
      this.selectedDistritoA.name
    );
  }

  cedulaSet(cedula: string) {
    this.cedulaA = cedula;
  }

  user(usernames: string) {
    this.username = usernames;
  }

  passwordSet(password: string) {
    this.password = password;
  }

  nombreSet(nombre: string) {
    this.nombre = nombre;
  }

  apellido1Set(apellido1: string) {
    this.apellido1 = apellido1;
  }

  apellido2Set(apellido2: string) {
    this.apellido2 = apellido2;
  }

  dobSet(dob) {
    this.year = (dob[0] + dob[1] + dob[2] + dob[3]) * 1;
    this.month = (dob[5] + dob[6]) * 1;
    this.day = (dob[8] + dob[9]) * 1;
    console.log(this.day);
  }

  telefonoSet(telefono: string) {
    this.telefono = telefono;
  }

  sinpeSet(sinpe: string) {
    this.sinpe = sinpe;
  }
  rolSet(rol){
    this.rolA = rol;
  }
}
