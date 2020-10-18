import { Injectable } from '@angular/core';
import {ProvinciaI, CantonI, DistritoI} from '../models/model.interface';

@Injectable({
  providedIn: 'root'
})
export class DatasService {
  private provincia : ProvinciaI[] = [
    {
      id:0,
      name:'Selecciona la provincia'
    },
    {
      id:1,
      name:'San José'
    },
    {
      id:2,
      name:'Alajuela'
    },
    {
      id:3,
      name:'Cartago'
    },
    {
      id:4,
      name:'Heredia'
    },
    {
      id:5,
      name:'Puntarenas'
    },
    {
      id:6,
      name:'Guanacaste'
    },
    {
      id:7,
      name:'Puntarenas'
    }
  ];

  private cantones : CantonI[] = [
    {
      id:0,
      provinciaId:0,
      name:'Selecciona tu Cantón'
    },
    {
      id:1,
      provinciaId:1,
      name:'San José'
    },
    {
      id:2,
      provinciaId:1,
      name:'Acosta'
    },
    {
      id:3,
      provinciaId:2,
      name:'Alajuela'
    }
  ];

  private distritos : DistritoI[] = [
    {
      id:1,
      cantonId:1,
      name:'Hatillo'
    },
    {
      id:2,
      cantonId:2,
      name:'Zarcero'
    },
    {
      id:3,
      cantonId:3,
      name:'Poás'
    }
  ];

  getProvincias(): ProvinciaI[]{
    return this.provincia;
  }

  getCantones() : CantonI[]{
    return this.cantones;
  }

  getDistritos() : DistritoI[]{
    return this.distritos;
  }
 
}
