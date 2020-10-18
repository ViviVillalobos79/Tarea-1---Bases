import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  // FormControl es un elemento de control que permite el manejo de los datos ingresados por el usuario
  name = new FormControl('');
  pass = new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

}
