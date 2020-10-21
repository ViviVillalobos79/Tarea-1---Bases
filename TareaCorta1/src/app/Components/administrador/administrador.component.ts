import {Component} from '@angular/core'

@Component({
    selector: 'administrador',
    templateUrl: './administrador.component.html',
    styleUrls: ['./administrador.component.css']
})

export class Administrador{
    i=0;
    img=["../../../assets/Images/Image1.png",
            '../../../assets/Images/Image2.png',
            '../../../assets/Images/Image5.png',
            '../../../assets/Images/Image6.png',
            '../../../assets/Images/Image30.png']

    
    constructor(){}
    left() {
        if (this.i > 0) {
          this.i = this.i - 1;
        }
      }
    
      right() {
        if (this.i < 4) {
          this.i = this.i + 1;
        }
      }
}