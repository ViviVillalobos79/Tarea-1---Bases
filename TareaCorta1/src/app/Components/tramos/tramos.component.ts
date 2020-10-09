import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tramos',
  templateUrl: './tramos.component.html',
  styleUrls: ['./tramos.component.css']
})
export class TramosComponent implements OnInit {
  tramos=["Productor 1",
          "Productor 2",
          "Productor 3",
          "Productor 4",
          "Productor 5"]

  constructor() { }

  ngOnInit(): void {
  }

}
