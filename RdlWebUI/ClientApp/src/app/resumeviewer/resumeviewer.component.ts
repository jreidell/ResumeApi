import { Component, OnInit, Injectable } from '@angular/core';
import { ResumeViewerService } from './resumeviewer.service';

@Component({
  selector: 'app-resumeviewer',
  templateUrl: './resumeviewer.component.html',
  styleUrls: ['./resumeviewer.component.css']
})
@Injectable()
export class ResumeViewerComponent implements OnInit {

  public resumes;

  constructor(private _resumeviewer: ResumeViewerService) { }

  ngOnInit() {
    this.getResumeData();
  }

  getResumeData() {
    this._resumeviewer.getResumeById().subscribe(
      // the first argument is a function which runs on success
      data => { this.resumes = data },
      // the second argument is a function which runs on error
      err => console.error(err),
      // the third argument is a function which runs on completion
      () => console.log('done loading resumes')
    );
  }

}

