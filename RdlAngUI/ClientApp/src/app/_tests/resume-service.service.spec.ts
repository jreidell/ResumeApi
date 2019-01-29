import { TestBed } from '@angular/core/testing';

import { ResumeService } from '../_services/resume-service.service';

describe('ResumeServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ResumeService = TestBed.get(ResumeService);
    expect(service).toBeTruthy();
  });
});
