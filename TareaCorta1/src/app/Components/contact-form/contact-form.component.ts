import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ProvinciaI, CantonI, DistritoI} from '../../models/model.interface'
import { DatasService} from '../../services/datas.service'

@Component({
  selector: 'contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css'],
  providers:[DatasService],
})
export class ContactFormComponent {

  public selectedProvincia: ProvinciaI={id: 0, name:''};
  public selectedProvinciaA: ProvinciaI={id: 0, name:''};
  public selectedCanton: CantonI={id: 0, name:'', provinciaId:0};
  public selectedCantonA: CantonI={id: 0, name:'', provinciaId:0};
  public selectedDistrito: DistritoI={id:0, name:'',cantonId:0};
  public selectedDistritoA: DistritoI={id:0, name:'',cantonId:0};
  public provincias: ProvinciaI[];
  public cantones: CantonI[];
  public distritos: DistritoI[];

  
  cedula = new FormControl('');
  
  

  myForm: FormGroup;
  nombre: string;
  apellido1: string;
  username:string;
  password:string;
  year: number;
  month: number;
  day: number;
  telefono: number;
  sinpe: number;

  ngOnInit(){
    this.provincias = this.datasServices.getProvincias();
    console.log(this.provincias);
  }


  constructor(
    public fb: FormBuilder, private datasServices: DatasService
  ){
    
    this.myForm = this.fb.group({
      'cedula': ['', [Validators.required, Validators.min(100000000),Validators.max(999999999)]],
      'usuario' : ['', [Validators.required, Validators.minLength(10),Validators.maxLength(10)]],
      'pass' : ['', [Validators.required, Validators.minLength(10),Validators.maxLength(10)]],
      'nombre' : ['', [Validators.required]],
      'apellido1' : ['', [Validators.required]],
      'apellido2' : ['', [Validators.required]],
      'provincia' : ['', [Validators.required]],
      'canton' : ['', [Validators.required]],
      'distrito' : ['', [Validators.required]],
      'dob' : ['', [Validators.required]],
      'telefono': ['', [Validators.required, Validators.min(60000000),Validators.max(89999999)]],
      'sinpe': ['', [Validators.required, Validators.min(60000000),Validators.max(89999999)]],
      

    })
  }


  cedula_check(x : number){
    let ced_len = x.toString().length
    return (ced_len != 9)

  }

  saveData(){
    //Vuelve al home page
    let jsonMsg = {
      "Cedula" : this.cedula,
      "Usuario" : this.username,
      "Nombre" : { 
          "Primer_Nombre" : this.nombre,
          "Apellido1" : this.apellido1,
          "Apellido2" : this.apellido2
      },
      "direccion" : {
          "Provincia" : "Limon",
          "Canton" : "Pococi",
          "Distrito" : "Guapiles"
      },
      "dob" : {
          "Dia" : 3,
          "Mes" : 9,
          "Year" : 1996
      },
      "telefono" : 61682819,
      "SINPE" : 88566646,
      "pass" : "yellow68",
      "pedidos":  [ 
          2848,
          4562]
  }
  ;
  console.log(jsonMsg);
  }

  //Guarda la provincia
  onSelect(id:number):void{
    this.cantones = this.datasServices.getCantones().filter((item : CantonI) => item.provinciaId == id);

    let provinciasTemp = this.datasServices.getProvincias().filter((item : ProvinciaI) => item.id == id);
    provinciasTemp.forEach(element => {
      if(element.id == id){
        this.selectedProvinciaA = element;
      }
    });
  }

  //Guarda el cantón
  onSelect2(id:number):void{
    this.distritos = this.datasServices.getDistritos().filter((item : DistritoI) => item.cantonId == id);

    let cantonesTemp = this.datasServices.getCantones().filter((item : CantonI) => item.id == id);
    cantonesTemp.forEach(element => {
      if(element.id == id){
        this.selectedCantonA = element;
      }
    });
  }

  //Guarda el distrito
  onSelect3(id:number):void{
    let distritosTemmp: DistritoI[] = this.datasServices.getDistritos().filter
    ((item : DistritoI) => (item.cantonId == this.selectedCanton.id && item.id== id));

    distritosTemmp.forEach(element => {
      if(element.id == id && element.cantonId == this.selectedCanton.id){
        this.selectedDistritoA = element;
      }
      
    });
    console.log(this.selectedProvinciaA);
    console.log(this.selectedCantonA);
    console.log(this.selectedDistritoA);
  }

  user(usernames:string){
    this.username = usernames;
  }

  passwordSet(password:string){
    this.password = password;
  }

  nombreSet(nombre:string){
    this.nombre = nombre;
  }

  apellido1Set(apellido1:string){
    this.apellido1 = apellido1;
  }

  apellido2Set(apellido2:string){
    this.apellido1 = apellido2;
  }

  dobSet(dob){
    this.year = (dob[0]+dob[1]+dob[2]+dob[3])*1;
    this.month = (dob[5]+dob[6])*1;
    this.day = (dob[8]+dob[9])*1;;
  }

  telefonoSet(telefono:number){
    this.telefono = telefono;
  }

  sinpeSet(sinpe:number){
    this.sinpe = sinpe;
  }
  

  

}
