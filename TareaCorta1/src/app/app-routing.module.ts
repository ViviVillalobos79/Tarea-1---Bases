import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Administrador } from './Components/administrador/administrador.component'
import { Productor } from './Components/productor/productor.component';
import { GestionProdsClientes } from './Components/gestionprodsclientes/gestionprodsclientes.component';
import { GestionCategorias } from './Components/gestioncategorias/gestioncategorias.component';
import { GestionProductos } from './Components/gestionproductos/gestionproductos.component';
import { Categorias } from './Components/categorias/categorias.component';
import { AgregarProds } from './Components/agregarprods/agregarprods.component';
import { Pedidos } from './Components/pedidos/pedidos.component';
import { AdminAfiliados } from './Components/adminafiliados/adminafiliados.component';
import { Login } from './Components/login/login.component';
import { TramoProductor } from './Components/tramoproductor/tramoproductor.component';
import { VistaPublicoComponent } from './Components/vistapublico/vistapublico.component';
import { CarritoCompras } from './Components/carritocompras/carritocompras.component';
import { TramosComponent } from './Components/tramos/tramos.component';
import { FeedbackComponent } from './Components/feedback/feedback.component';
import { ComprobanteComponent } from './Components/comprobante/comprobante.component';
import { ContactFormComponent } from './Components/contact-form/contact-form.component';

//* en este modulo se importan las vistas para agregarles un nombre de dirección y asignarle un componente
 
const routes: Routes = [
{
  path: 'home',
  component: VistaPublicoComponent
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
},
{
  path: 'tramos',
  component: TramosComponent
},
{
  path: 'feedback',
  component: FeedbackComponent
},
{
  path: 'comprobante',
  component: ComprobanteComponent
},
{
  path: 'signin',
  component: ContactFormComponent
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }