import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { AccountService } from '../../../services/account.service';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { Subscription } from 'rxjs';
import { Register } from '../../../models/register.model';
import { HttpErrorResponse } from '@angular/common/http';
import { MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule, ReactiveFormsModule,
    MatButtonModule, MatFormFieldModule, MatInputModule, MatDatepickerModule,
    MatRadioModule
  ],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit, OnDestroy {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);
  subscribedRegisterUser: Subscription | undefined;
  errors: string[] | undefined;

  minDate = new Date();
  maxDate = new Date();

  passwordsNotMatch: boolean | undefined;

  ngOnInit(): void {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 99, 0, 1);
    this.maxDate = new Date(currentYear - 18, 0, 1);
  }

  ngOnDestroy(): void {
    this.subscribedRegisterUser?.unsubscribe();
  }

  registerFg = this.fB.group({
    emailCtrl: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]], 
    userNameCtrl: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
    dateOfBirthCtrl: ['', [Validators.required]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
    genderCtrl: ['female', [Validators.required]]
  });

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get UserNameCtrl(): FormControl {
    return this.registerFg.get('userNameCtrl') as FormControl;
  }

  get DateOfBirthCtrl(): FormControl {
    return this.registerFg.get('dateOfBirthCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }

  get GenderCtrl(): FormControl {
    return this.registerFg.get('genderCtrl') as FormControl;
  }

  register(): void {
    const dob: string | undefined = this.getDateOnly(this.DateOfBirthCtrl.value);

    if (this.PasswordCtrl.value === this.ConfirmPasswordCtrl.value) {
      let user: Register = {
        email: this.EmailCtrl.value,
        userName: this.UserNameCtrl.value,
        dateOfBirth: dob,
        password: this.PasswordCtrl.value,
        confirmPassword: this.ConfirmPasswordCtrl.value,
        gender: this.GenderCtrl.value
      }

      this.subscribedRegisterUser = this.accountService.register(user).subscribe({
        next: (res) => console.log(res),
        error: (err: HttpErrorResponse) => {
          if (err.error.errors) {
            this.errors = err.error.errors
          }
        }
      })
    }
    else {
      this.passwordsNotMatch = true;
    }
  }

  getDateOnly(dob: string | null): string | undefined {
    if (!dob) return undefined;

    let theDob: Date = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes() - theDob.getTimezoneOffset())).toISOString().slice(0, 10);
  }
}