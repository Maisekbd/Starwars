import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    errorMessage: string = "";
    
  get UserRoles(): string[] {
      let user = this.jwtHelper.decodeToken(localStorage.getItem('currentUser'));
      let roleArr: string[] = [];
      for (let role of user.role) {
          roleArr.push(role);
      }
      return roleArr;
  };
  constructor(
    private router: Router,
    private http: HttpClient,
    private jwtHelper: JwtHelperService,
    @Inject(APP_CONFIG) private config: AppConfig) {

  }

  login(credentials: string) {
    var result;
    let userIdvar: string = "";
    //TO-DO Uncomment till transfer dlls ti aminah
    return this.http.post(`${this.config.apiEndpoint}/Account/Login`, credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    })
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
            userIdvar = this.jwtHelper.decodeToken(JSON.stringify(user)).unique_name;

          return false;
        }
        return true;
      }));

  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }




  GetUserData() {
    let user = localStorage.getItem('currentUser');
    return this.jwtHelper.decodeToken(JSON.stringify(user));
  }



}
