import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Administrador } from './Components/administrador/administrador.component'
import { Productor } from './Components/productor/productor.component';
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

const routes: Routes = [
{
  path: 'home',
  component: VistaPublico
},
{
  path:'',
  redirectTo: 'home',
  pathMatch: 'full'
},
{
  path: 'administrador',
  component: Administrador
},
{
  path: 'productor',
  component: Productor
},
{
  path: 'afiliacion',
  component: Afiliacion
},
{
  path: 'gestionprodsclientes',
  component: GestionProdsClientes
},
{
  path: 'gestioncategorias',
  component: GestionCategorias
},
{
  path: 'gestionproductos',
  component: GestionProductos
},
{
  path: 'categorias',
  component: Categorias
},
{
  path: 'reportes',
  component: Reportes
},
{
  path: 'agregarprods',
  component: AgregarProds
},
{
  path: 'pedidos',
  component: Pedidos
},
{
  path: 'adminafiliados',
  component: AdminAfiliados
},
{
  path: 'login',
  component: Login
},
{
  path: 'tramoproductor',
  component: TramoProductor
},
{
  path: 'carritocompras',
  component: CarritoCompras
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
