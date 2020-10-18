import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackPresComponent } from './feedback-pres.component';

describe('FeedbackPresComponent', () => {
  let component: FeedbackPresComponent;
  let fixture: ComponentFixture<FeedbackPresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeedbackPresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackPresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
