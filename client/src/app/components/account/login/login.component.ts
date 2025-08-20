import { Component, OnDestroy, inject } from '@angular/core';
import { AccountService } from '../../../services/account.service';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Login } from '../../../models/login.model';
import { RouterLink } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule, ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule, MatInputModule, MatButtonModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnDestroy {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);
  subscribedRegisterUser: Subscription | undefined;

  ngOnDestroy(): void {
    this.subscribedRegisterUser?.unsubscribe();
  }

  loginFg = this.fB.group({
    emailCtrl: ['', [Validators.required, Validators.email]],
    passwordCtrl: ['']
  })

  get EmailCtrl(): FormControl {
    return this.loginFg.get('emailCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.loginFg.get('passwordCtrl') as FormControl;
  }

  login(): void {
    let userInput: Login = {
      email: this.EmailCtrl.value,
      password: this.PasswordCtrl.value
    }

    this.accountService.login(userInput).subscribe();
  }
}