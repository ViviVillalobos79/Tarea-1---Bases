import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-feedback-pres',
  templateUrl: './feedback-pres.component.html',
  styleUrls: ['./feedback-pres.component.css']
})
export class FeedbackPresComponent implements OnInit {

  constructor(private _route: ActivatedRoute) {
    console.log(this._route.snapshot.paramMap.get('id'));
   }

  ngOnInit(): void {
  }

}
