import { TestBed, inject } from '@angular/core/testing';

import { ExamStatusService } from './exam-status.service';

describe('ExamStatusService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExamStatusService]
    });
  });

  it('should be created', inject([ExamStatusService], (service: ExamStatusService) => {
    expect(service).toBeTruthy();
  }));
});
