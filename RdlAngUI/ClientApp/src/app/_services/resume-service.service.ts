import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { CareerInfo, Globals } from '../_models';

// 'application/x-www-form-urlencoded'
// 'application/json'

const apiUrl = 'https://rdlsvc.azurewebsites.net/api/v1/CareerInfo';

@Injectable({
  providedIn: 'root'
})
export class ResumeService {

  constructor(private http: HttpClient, private globals: Globals) { }

  getResumeData(id: string): Observable<CareerInfo[]>  {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.globals.token}`
    });

    const options = {
      headers: headers
    };

    return this.http.get<CareerInfo[]>(`${apiUrl}/${id}`, options);
  }

}
