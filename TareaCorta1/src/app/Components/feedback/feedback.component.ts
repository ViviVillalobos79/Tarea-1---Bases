import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  feedbackProductor = new FormControl('');
  feedbackProducto = new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

}
