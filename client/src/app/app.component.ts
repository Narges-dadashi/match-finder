import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppUser } from './models/app-user.model';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from './services/account.service';
import { Login } from './models/login.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
    FormsModule, ReactiveFormsModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);

  registerFg = this.fB.group({
    emailCtrl: '',
    userNameCtrl: '',
    passwordCtrl: '',
    confirmPasswordCtrl: '',
    ageCtrl: 0,
    cityCtrl: '',
    countryCtrl: ''
  })

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get UserNameCtrl(): FormControl {
    return this.registerFg.get('userNameCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }

  get AgeCtrl(): FormControl {
    return this.registerFg.get('ageCtrl') as FormControl;
  }

  get CityCtrl(): FormControl {
    return this.registerFg.get('cityCtrl') as FormControl;
  }

  get CountryCtrl(): FormControl {
    return this.registerFg.get('countryCtrl') as FormControl;
  }

  register(): void {
    let user: AppUser = {
      email: this.EmailCtrl.value,
      userName: this.UserNameCtrl.value,
      password: this.PasswordCtrl.value,
      confirmPassword: this.ConfirmPasswordCtrl.value,
      age: this.AgeCtrl.value,
      city: this.CityCtrl.value,
      country: this.CountryCtrl.value
    }

    this.accountService.register(user).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err.error)
    });
  }

  login(): void {
    let userInput: Login = {
      email: 'a1@agmail.com',
      password: '12345678'
    }

    this.accountService.login(userInput).subscribe();
  }






















  //   fB = inject(FormBuilder);
  //   http = inject(HttpClient);

  //   receivedUser: AppUser | undefined;
  //   receivedUsers: AppUser[] | undefined;
  //   errorMessage: string = '';

  //   registerFg = this.fB.group({
  //     emailCtrl: ['', [Validators.required, Validators.email]],
  //     userNameCtrl: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
  //     ageCtrl: ['', [Validators.required, Validators.min(18), Validators.max(80)]],
  //     isAliveCtrl: ['', [Validators.required]]
  //   });

  //   get EmailCtrl(): FormControl {
  //     return this.registerFg.get('emailCtrl') as FormControl;
  //   }

  //   get UserNameCtrl(): FormControl {
  //     return this.registerFg.get('userNameCtrl') as FormControl;
  //   }

  //   get AgeCtrl(): FormControl {
  //     return this.registerFg.get('ageCtrl') as FormControl;
  //   }

  //   get IsAliveCtrl(): FormControl {
  //     return this.registerFg.get('isAliveCtrl') as FormControl;
  //   }

  //   create(): void {
  //     let appUser: AppUser = {
  //       email: this.EmailCtrl.value,
  //       userName: this.UserNameCtrl.value,
  //       age: this.AgeCtrl.value,
  //       isAlive: this.IsAliveCtrl.value
  //     }

  //     this.http.post<AppUser>('http://localhost:5000/api/user/create', appUser).subscribe({
  //       next: (response: AppUser) => (this.receivedUser = response, console.log(response)),
  //       error: (err) => (this.errorMessage = err.error, console.log(err.error))
  //     });
  //   }

  //   getAll(): void {
  //     this.http.get<AppUser[]>('http://localhost:5000/api/user').subscribe({
  //       next: (response: AppUser[]) => (this.receivedUsers = response, console.log(response))
  //     });
  //   }

  //   getByUserName(): void {
  //     this.http.get<AppUser>('http://localhost:5000/api/user/get-by-username/aa1').subscribe({
  //       next: (response: AppUser) => (this.receivedUser = response, console.log(response)),
  //       error: (errMessage) => (this.errorMessage = errMessage.error, console.log(errMessage.error))
  //     });
  //   }

  //   update(): void {
  //     let appUser: AppUser = {
  //       email: this.EmailCtrl.value,
  //       userName: this.UserNameCtrl.value,
  //       age: this.AgeCtrl.value,
  //       isAlive: this.IsAliveCtrl.value
  //     }

  //     this.http.put(
  //       'http://localhost:5000/api/user/update/67ac637c721f96173a90a39a', appUser).subscribe();
  //   }

  //   delete(): void {
  //     this.http.delete<AppUser>('http://localhost:5000/api/user/delete/67ac637c721f96173a90a39a')
  //       .subscribe({
  //         error: (err) => (this.errorMessage = err.error, console.log(err.error))
  //       });
  //   }
}

// fB = inject(FormBuilder);
// http = inject(HttpClient);

// receivedUser: AppUser | undefined;
// receivedUsers: AppUser[] | undefined;
// errorMessage: string = '';

// registerFg = this.fB.group({
//   emailCtrl: ['', [Validators.required, Validators.email]],
//   nameCtrl: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
//   ageCtrl: ['', [Validators.required, Validators.min(18), Validators.max(80)]],
//   passwordCtrl: ['', [Validators.required, Validators.min(8), Validators.max(16)]],
//   confirmPasswordCtrl: ['', [Validators.required, Validators.min(8), Validators.max(16)]]
// });

// get EmailCtrl(): FormControl {
//   return this.registerFg.get('emailCtrl') as FormControl;
// }

// get NameCtrl(): FormControl {
//   return this.registerFg.get('nameCtrl') as FormControl;
// }

// get AgeCtrl(): FormControl {
//   return this.registerFg.get('ageCtrl') as FormControl;
// }

// get PasswordCtrl(): FormControl {
//   return this.registerFg.get('passwordCtrl') as FormControl;
// }

// get ConfirmPasswordCtrl(): FormControl {
//   return this.registerFg.get('confirmPasswordCtrl') as FormControl;
// }

// registerUser(): void {
//   let appUser: AppUser = {
//     email: this.EmailCtrl.value,
//     userName: this.NameCtrl.value,
//     age: this.AgeCtrl.value,
//     password: this.PasswordCtrl.value,
//     confirmPassword: this.ConfirmPasswordCtrl.value
//   }

//   this.http.post<AppUser>('http://localhost:5000/api/user/register', appUser)
//     .subscribe({
//       next: (response: AppUser) => (this.receivedUser = response, console.log(response)),
//       error: (err) => (this.errorMessage = err.error, console.log(err.error))
//     });
// }

// getAll(): void {
//   this.http.get<AppUser[]>('http://localhost:5000/api/user').subscribe({
//     next: (response: AppUser[]) => (this.receivedUsers = response, console.log(response))
//   });
// }

// getByUserName(): void {
//   this.http.get<AppUser>('http://localhost:5000/api/user/get-by-username/aa2').subscribe({
//     next: (response: AppUser) => (this.receivedUser = response, console.log(response)),
//     error: (errMessage) => (this.errorMessage = errMessage.error, console.log(errMessage.error))
//   });
// }

// update(): void {
//   let appUser: AppUser = {
//     email: this.EmailCtrl.value,
//     userName: this.NameCtrl.value,
//     age: this.AgeCtrl.value,
//     password: this.PasswordCtrl.value,
//     confirmPassword: this.ConfirmPasswordCtrl.value
//   }

//   this.http.put(
//     'http://localhost:5000/api/user/update/67a47d35000368a49f33bb9d', appUser
//     ).subscribe();
// }

// delete(): void {
//   this.http.delete<AppUser>('http://localhost:5000/api/user/delete/67a47d35000368a49f33bb9d').subscribe({
//     error: (err) => (this.errorMessage = err.error, console.log(err.error))
//   });
// }

// setValue(): void {
//   console.log(this.EmailCtrl.value),
//     console.log(this.NameCtrl.value),
//     console.log(this.AgeCtrl.value),
//     console.log(this.PasswordCtrl.value),
//     console.log(this.ConfirmPasswordCtrl.value)
// }