import { Component, inject, OnInit, PLATFORM_ID } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet, RouterModule } from '@angular/router';
import { AccountService } from './services/account.service';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { FooterComponent } from "./components/footer/footer.component";
import { isPlatformBrowser } from '@angular/common';
import { NgxSpinnerModule } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, RouterModule,
    FormsModule, ReactiveFormsModule,
    MatButtonModule,
    NavbarComponent,
    FooterComponent, NgxSpinnerModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  accountService = inject(AccountService);
  platformId = inject(PLATFORM_ID);

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      let loggedInUserStr: string | null = localStorage.getItem('loggedInUser');
      console.log(loggedInUserStr);

      if (loggedInUserStr != null) {
        this.accountService.authorizeLoggedInUser();

        this.accountService.setCurrentUser(JSON.parse(loggedInUserStr))
      }
    }
  }
}