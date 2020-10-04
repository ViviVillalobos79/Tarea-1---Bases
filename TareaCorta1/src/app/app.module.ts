import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Administrador } from './Components/administrador/administrador.component'
import { Productor } from './Components/productor/productor.component'
import { Afiliacion } from './Components/afiliacion/afiliacion.component';
import { GestionProdsClientes } from './Components/gestionprodsclientes/gestionprodsclientes.component';
import { GestionCategorias } from './Components/gestioncategorias/gestioncategorias.component';
import { GestionProductos } from './Components/gestionproductos/gestionproductos.component';
import { Categorias } from './Components/categorias/categorias.component';
import { Reportes } from './Components/reportes/reportes.component';
import { AgregarProds } from './Components/agregarprods/agregarprods.component';
import { Pedidos } from './Components/pedidos/pedidos.component';
import { AdminAfiliados } from './Components/adminafiliados/adminafiliados.component';
import { Login } from './Components/login/login.component';
import { TramoProductor } from './Components/tramoproductor/tramoproductor.component';
import { VistaPublico } from './Components/vistapublico/vistapublico.component';
import { CarritoCompras } from './Components/carritocompras/carritocompras.component';


@NgModule({
  declarations: [
    AppComponent,
    Administrador,
    Productor,
    Afiliacion,
    GestionProdsClientes,
    GestionCategorias,
    GestionProductos,
    Categorias,
    Reportes,
    AgregarProds,
    Pedidos,
    AdminAfiliados,
    Login,
    TramoProductor,
    VistaPublico,
    CarritoCompras
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
