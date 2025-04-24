import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { Member } from '../../models/member.model';

@Component({
  selector: 'app-member',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './member.component.html',
  styleUrl: './member.component.scss'
})
export class MemberComponent {
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