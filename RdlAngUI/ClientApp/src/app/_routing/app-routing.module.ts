import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeViewerComponent } from '../resume-viewer/resume-viewer.component';
import { OverviewComponent } from '../overview/overview.component';

const routes: Routes = [
  // THIS DECLARES A DEFAULT ROUTE AND SETS IT TO OVERVIEW
  { path: '', redirectTo: '/overview', pathMatch: 'full' },
  { path: 'overview', component: OverviewComponent },
  { path: 'resume', component: ResumeViewerComponent },
  // CATCH ALL AND REDIRECT TO ROOT
  { path: '**', redirectTo: '/overview' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule { }
