import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 //endpoint: string = 'http://localhost:32915/AuthenticateUser';
 endpoint: string = 'https://eauctionsellerapi.azurewebsites.net//AuthenticateUser';
  //headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};
  
  constructor(private http: HttpClient, public router: Router) { }

   // Sign-in
   signIn(email: string) {
     console.log( 'signin',email);
     const auth_token='123';
     const httpOptions = {
      //headers: new HttpHeaders({        
        //Authorization: 'my-auth-token'}), 
      params:new HttpParams().set("email", email)}
     const headers = new Headers({
      'Content-Type': 'application/json'
     // 'CorrelationId': '1',
     // 'Authorization': `Bearer ${auth_token}`
    })
    console.log('headers',headers);
     let params = new HttpParams().set("email", email);

    return this.http.get<any>(`${this.endpoint}`, httpOptions).pipe(catchError(this.handleError))
     }

  getToken() {
    return localStorage.getItem('access_token');
  }
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
  }
  doLogout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['log-in']);
    }
  }
  // User profile
  /* getUserProfile(id: any): Observable<any> {
    let api = `${this.endpoint}/user-profile/${id}`;
    return this.http.get(api, { headers: this.headers }).pipe(
      map((res) => {
        return res || {};
      }),
      catchError(this.handleError)
    );
  } */
  // Error
  private handleError(err:HttpErrorResponse){
console.log("Error handler in");
    return throwError(()=>err.message);
  }
  }

