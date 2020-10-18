import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
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

  myForm: FormGroup;

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
      'distrito' : ['', [Validators.required]]

    })
  }

  log(x) { console.log(x);}

  cedula_check(x : number){
    let ced_len = x.toString().length
    return (ced_len != 9)

  }

  saveData(){
    console.log(this.log(this.myForm.invalid));
  }

  onSelect(id:number):void{
    this.cantones = this.datasServices.getCantones().filter((item : CantonI) => item.provinciaId == id);

    let provinciasTemp = this.datasServices.getProvincias().filter((item : ProvinciaI) => item.id == id);
    provinciasTemp.forEach(element => {
      if(element.id == id){
        this.selectedProvinciaA = element;
      }
    });
  }

  onSelect2(id:number):void{
    this.distritos = this.datasServices.getDistritos().filter((item : DistritoI) => item.cantonId == id);

    let cantonesTemp = this.datasServices.getCantones().filter((item : CantonI) => item.id == id);
    cantonesTemp.forEach(element => {
      if(element.id == id){
        this.selectedCantonA = element;
      }
    });
  }
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


}
