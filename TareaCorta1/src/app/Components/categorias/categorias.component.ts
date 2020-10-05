import {Component} from '@angular/core'

@Component({
    selector: 'categorias',
    templateUrl: './categorias.component.html',
    styleUrls: ['./categorias.component.css']
})

export class Categorias{

    categorias = [{"ID":"1","Categoria":"Verduras"},{"ID":"2","Categoria":"Frutas"},{"ID":"3","Categoria":"Hortalizas"}]
    
}