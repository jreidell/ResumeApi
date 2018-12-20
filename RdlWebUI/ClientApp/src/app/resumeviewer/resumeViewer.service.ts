import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class ResumeViewerService {

  constructor(private http: HttpClient) { }

  // Uses http.get() to load data from a single API endpoint
  getResumes() {
    return this.http.get('https://rdlsvc.azurewebsites.net/api/v1/CareerInfo');
    //return this.http.get('https://localhost:44389/api/v1/CareerInfo');
  }

  // Uses http.get() to load data from a single API endpoint
  getResumeById() {
    
    //return this.http.get('https://localhost:44389/api/v1/CareerInfo?id=21a61a6a-6554-4e7f-a974-08d663d5d19f');
    return this.http.get('https://rdlsvc.azurewebsites.net/api/v1/CareerInfo?id=6932ffbf-036b-48b8-82c4-08d6669a016c');
  }
}
