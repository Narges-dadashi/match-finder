import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserWithRole } from '../../../models/user-with-role';
import { take } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-admin-panel',
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatTableModule, MatButtonModule, MatIconModule
  ],
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.scss'
})
export class AdminPanelComponent implements OnInit {
  private _adminService = inject(AdminService);
  private _snackbar = inject(MatSnackBar);

  displayedColumns = ['no', 'username', 'active-roles', 'delete-user'];
  usersWithRoles: UserWithRole[] = [];

  ngOnInit(): void {
    this.showAllUsersWithRoles();
  }

  showAllUsersWithRoles(): void {
    this._adminService.getUsersWithRoles()
      .pipe(take(1))
      .subscribe({
        next: (res) => this.usersWithRoles = res
      });
  }

  deleteUser(index: number, userName: string): void {
    this._adminService.deleteUser(userName)
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          this._snackbar.open(res.message, 'Close', {
            horizontalPosition: 'center',
            verticalPosition: 'top',
            duration: 7000
          });

          if (this.usersWithRoles)
            this.usersWithRoles = [
              ...this.usersWithRoles.slice(0, index),
              ...this.usersWithRoles.slice(index + 1)
            ]
        }
      });
  }
}