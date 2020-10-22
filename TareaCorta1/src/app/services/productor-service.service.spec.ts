import { TestBed } from '@angular/core/testing';

import { ProductorServiceService } from './productor-service.service';

describe('ProductorServiceService', () => {
  let service: ProductorServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductorServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
