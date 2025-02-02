import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  // FormControl es un elemento de control que permite el manejo de los datos ingresados por el usuario
  feedbackProductor = new FormControl('');
  feedbackProducto = new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

}
