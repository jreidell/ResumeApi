import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Globals } from '../_models';
import { AuthService } from '../_services';
import { tap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private globals: Globals, private auth: AuthService) {  }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available

        return next.handle(request).pipe(tap((event: HttpEvent<any>) => {
            if (this.globals.token) {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${this.globals.token}`
                    }
                });
            }
            if (event instanceof HttpResponse) {
                // do something with the response
            }
          }, (err: any) => {
            if (err instanceof HttpErrorResponse) {
              if (err.status === 401) {
                this.auth.getToken();              }
            }
          }));
    }
}
