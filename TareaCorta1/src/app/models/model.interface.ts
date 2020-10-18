export interface ProvinciaI {
    id:number;
    name:string;
}

export interface CantonI {
    id:number;
    provinciaId:number;
    name:string;
}

export interface DistritoI {
    id:number;
    cantonId:number;
    name:string;
}