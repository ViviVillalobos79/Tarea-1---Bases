import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'productor',
  templateUrl: './productor.component.html',
  styleUrls: ['./productor.component.css'],
})
export class Productor {
  cedula: string;
  i = 0;
  img = [
    '../../../assets/Images/Image1.png',
    '../../../assets/Images/Image2.png',
    '../../../assets/Images/Image5.png',
    '../../../assets/Images/Image6.png',
    '../../../assets/Images/Image30.png',
  ];

  constructor(private _route: ActivatedRoute) {
    console.log(this._route.snapshot.paramMap.get('id'));
      this.cedula = this._route.snapshot.paramMap.get('id');
  }
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
