import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../services/account.service';
import { ExampleService } from '../../services/example.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports: [
        RouterLink, CommonModule,
        MatToolbarModule, MatIconModule,
        MatButtonModule, MatMenuModule,
        MatDividerModule, MatListModule
    ],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
    accountService = inject(AccountService);
    exampleService = inject(ExampleService);

    logout(): void {
        this.accountService.logout();
    }
}