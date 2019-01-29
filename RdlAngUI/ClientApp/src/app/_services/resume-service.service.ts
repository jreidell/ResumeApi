import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { CareerInfo } from '../_models';

// 'application/x-www-form-urlencoded'
// 'application/json'
const headers = new HttpHeaders({
  'Content-Type': 'application/json'
});

const options = {
  headers: headers
}

const apiUrl = 'https://rdlsvc.azurewebsites.net/api/v1/CareerInfo';

@Injectable({
  providedIn: 'root'
})
export class ResumeService {

  constructor(private http: HttpClient) { }

  getResumeData(id: string): Observable<CareerInfo[]>  {
    return this.http.get<CareerInfo[]>(`${apiUrl}/${id}`, options);
  }

}
