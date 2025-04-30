import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Member } from '../../models/member.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-member',
  standalone: true,
  imports: [
    MatCardModule, MatIconModule
  ],
  templateUrl: './member.component.html',
  styleUrl: './member.component.scss'
})
export class MemberComponent implements OnInit {
  accountService = inject(AccountService);
  members: Member[] | undefined;

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.accountService.getAllMember().subscribe({
      next: (res) => {
        this.members = res;
      }
    });
  }
}