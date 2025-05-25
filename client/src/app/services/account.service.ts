import { HttpClient } from '@angular/common/http';
import { inject, Injectable, PLATFORM_ID } from '@angular/core';
import { map, Observable } from 'rxjs';
import { LoggedIn } from '../models/logged-in.model';
import { AppUser } from '../models/app-user.model';
import { Login } from '../models/login.model';
import { Member } from '../models/member.model';
import { isPlatformBrowser } from '@angular/common';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  private readonly _baseApiUrl: string = 'http://localhost:5000/api/';
  platformId = inject(PLATFORM_ID);
  router = inject(Router);

  register(user: AppUser): Observable<LoggedIn> {
    let userResponse$: Observable<LoggedIn> =
      this.http.post<LoggedIn>(this._baseApiUrl + 'account/register', user);

    userResponse$.pipe(
      map(res => {
        this.setCurrentUser(res);

        return res;
      })
    );

    return userResponse$;
  }

  login(userInput: Login): Observable<LoggedIn> {
    let userResponse$: Observable<LoggedIn> =
      this.http.post<LoggedIn>(this._baseApiUrl + 'account/login', userInput);

    userResponse$.pipe(
      map(res => {
        this.setCurrentUser(res);

        return res;
      })
    );

    return userResponse$;
  }

  // register(user: AppUser): Observable<LoggedIn> {
  //   return this.http.post<LoggedIn>(
  //     this._baseApiUrl + 'account/register', user);
  // }

  // login(userInput: Login): Observable<LoggedIn> {
  //   return this.http.post<LoggedIn>(
  //     this._baseApiUrl + 'account/login', userInput).pipe(
  //       map(userResponse => {
  //         this.setCurrentUser(userResponse);

  //         return userResponse;
  //       })
  //     )
  // }

  setCurrentUser(loggedIn: LoggedIn): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('loggedInUser', JSON.stringify(loggedIn));
    }
  }
}