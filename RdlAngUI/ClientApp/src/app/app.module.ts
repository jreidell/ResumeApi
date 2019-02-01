import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule} from '@angular/material';
import { ResumeViewerComponent } from './resume-viewer/resume-viewer.component';
import { AppRoutingModule } from './_routing';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OverviewComponent } from './overview/overview.component';

import { JwtInterceptor } from './_net';
import { Globals } from './_models';

@NgModule({
  declarations: [
    AppComponent,
    ResumeViewerComponent,
    NavMenuComponent,
    OverviewComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    HttpClientModule,
    MatProgressBarModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    Globals],
  bootstrap: [AppComponent]
})
export class AppModule{}
