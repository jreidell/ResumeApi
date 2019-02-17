import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'; 

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class ResumeViewerService {

  //return this.http.get('https://localhost:44389/api/v1/CareerInfo');
  //MICROSERVICE URL
  //return this.http.get('https://localhost:8304/api/v1/CareerInfo');
  resumeUrl:string = 'https://rdlsvc.azurewebsites.net/api/v1/CareerInfo';

  //return this.http.get('https://localhost:44389/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f');
  //return this.http.get('https://rdlsvc.azurewebsites.net/api/v1/CareerInfo/58f21038-a7e4-46ec-b036-08d667882bcb');
  //MICROSERVICE URL
  //return this.http.get('https://localhost:8304/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f');
  resumeByIdUrl:string = 'https://rdlsvc.azurewebsites.net/api/v1/CareerInfo/58f21038-a7e4-46ec-b036-08d667882bcb';

  constructor(private http: HttpClient) { }

  // Uses http.get() to load data from a single API endpoint
  getResumes() {
    return this.http.get(this.resumeUrl);
  }

  // Uses http.get() to load data from a single API endpoint
  getResumeById() {
    return this.http.get(this.resumeByIdUrl);
  }


  //IDEALLY THIS WILL BE THE CALL THAT I GO WIH - NEED TO BUILD OUT INTERFACE(S)
  //getResumeById(): Observable<ICareerInfo[]> {  
  //  return this.http.get(resumeUrl).map((response: Response) => <ICareerInfo[]>response.json());  
  //}

}
