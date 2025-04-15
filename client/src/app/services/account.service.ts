import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoggedIn } from '../models/logged-in.model';
import { AppUser } from '../models/app-user.model';
import { login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);

  register(user: AppUser): Observable<LoggedIn> {
    return this.http.post<LoggedIn>('http://localhost:5000/api/user/create', user);
  }

  login(userInput: login): Observable<LoggedIn> {
    return this.http.post<LoggedIn>('http://localhost:5000/api/user/login', userInput);
  }
}