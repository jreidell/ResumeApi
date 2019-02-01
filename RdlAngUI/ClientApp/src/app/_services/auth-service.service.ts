import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TokenData } from '../_models';

const headers = new HttpHeaders({
  'Content-Type': 'application/json'
});

const options = {
  headers: headers
};

const apiUrl = 'https://rdlsvc.azurewebsites.net/api/v1/AuthUser/GetToken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  getToken(): Observable<TokenData> {
    return this.http.get<TokenData>(`${apiUrl}`, options);
  }

}
