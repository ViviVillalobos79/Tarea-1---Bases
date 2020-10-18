import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
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
import { VistaPublicoComponent } from './Components/vistapublico/vistapublico.component';
import { CarritoCompras } from './Components/carritocompras/carritocompras.component';
import { TramosComponent } from './Components/tramos/tramos.component';
import { FormsModule } from '@angular/forms';
import { FeedbackComponent } from './Components/feedback/feedback.component';
import { ComprobanteComponent } from './Components/comprobante/comprobante.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClientesService } from './clientes.service';
<<<<<<< HEAD
import { RegistrationComponent } from './Components/registration/registration.component';
import { FeedbackPresComponent } from './Components/feedback-pres/feedback-pres.component';
=======
import { ContactFormComponent } from './Components/contact-form/contact-form.component';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
>>>>>>> 61d4dcebe9b44d5a237872549ec7f549da7c8459


/* en este modulo se importa todo lo necesario para la implementacion de la solucion referente al FrontEnd
como por ejemplo los componentes de angular, asi mismo se importan los componentes o las vistas de la pagina web
*/ 

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
    VistaPublicoComponent,
    CarritoCompras,
    TramosComponent,
    FeedbackComponent,
    ComprobanteComponent,
<<<<<<< HEAD
    RegistrationComponent,
    FeedbackPresComponent
=======
    ContactFormComponent,
>>>>>>> 61d4dcebe9b44d5a237872549ec7f549da7c8459
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    FormsModule,
    BrowserAnimationsModule,
    DropDownListModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }