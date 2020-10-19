/**
 * Formato del json para la tabla Clientes
 */
export class Clientes{
    Cedula: number;
    Usuario: string;
    Nombre_Persona: {Primer_Nombre:string,Apellido1: string, Apellido2:string};
    direccion: {Provincia: string, Canton: string, Distrito: string};
    dob: {Dia: number, Mes: number, Year: number};
    telefono: number;
    SINPE: number;
    pass: string;
    pedidos: [];

    constructor(){
    }
}

/**
 * Formato del json para la tabla Categorias
 */
export class Categoria{
    IdCategoria: number;
    Nombre: string
}

/**
 * Formato del json para la tabla Direccion
 */
export class Direccion {
    Provincia: string;
    Canton: string;
    Distrito: string
}

/**
 * Formato del json para la tabla fecha de nacimiento
 */
export class DOB{
    Dia: number;
    Mes: number;
    Year: number
}

/**
 * Formato del json para la tabla Nombre de Personas
 */
export class Nombre_Persona{
    Primer_Nombre: string;
    Apellido1: string;
    Apellido2: string
}

/**
 * Formato del json para la tabla Pedido
 */
export class Pedido{
    num_pedido: number;
    productos: [];
    num_comprobante: number;
    Cedula_cliente: number;
    entregado: boolean
}

/**
 * Formato del json para la tabla Producto
 */
export class Producto{
    Num_Producto: number;
    Nombre: string;
    id_categoria: number;
    Precio: number;
    Cantidad: number;
    Modo_venta: string;
    Disponibilidad: boolean;
    CedulaProductor: number
}

/**
 * Formato del json para la tabla Productores 
 */
export class Productores{
    Cedula: number;
    Nombre: { Nombre_Persona: string, Apellido1: string, Apellido2: string}
    direccion:{ Provincia: string, Canton: string, Distrito: string};
    dob: {Dia: string, Mes: string, Year: string};
    telefono: number;
    SINPE: number;
    pass: string;
    productos:[];
    pedidos: []
}