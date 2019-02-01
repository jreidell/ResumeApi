import { Component, OnInit } from '@angular/core';
import { ResumeService, AuthService } from '../_services';
import { delay } from 'q';
import { Globals } from '../_models';

@Component({
  selector: 'app-resume-viewer',
  templateUrl: './resume-viewer.component.html',
  styleUrls: ['./resume-viewer.component.css']
})
export class ResumeViewerComponent implements OnInit {

  title = 'Reidell.net - Angular v6 Resume Viewer';
  public resumes;
  public noData = true;
  public millisecondsToWait = 4000;

  constructor(private svc: ResumeService, private auth: AuthService, private globals: Globals) { }

  async getResumeData() {
    // 58f21038-a7e4-46ec-b036-08d667882bcb
    await delay(this.millisecondsToWait);
    this.svc.getResumeData('').subscribe(
      data => { this.resumes = data; this.noData = false; },
      err => console.log(err),
      () => console.log('got resume!')
    );
  }

  // METHOD TO MIMIC Thread.Sleep(ms)
  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }

  ngOnInit() {
    this.getResumeData();
  }

}
