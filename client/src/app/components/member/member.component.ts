import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MemberService } from '../../services/member.service';
import { Member } from '../../models/member.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-member',
  standalone: true,
  imports: [
    RouterLink,
    MatCardModule, MatIconModule
  ],
  templateUrl: './member.component.html',
  styleUrl: './member.component.scss'
})
export class MemberComponent {
  memberService = inject(MemberService);
  members: Member[] | undefined;

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    let allMember$: Observable<Member[]> = this.memberService.getAllMembers();

    allMember$.subscribe({
      next: (res) => {
        this.members = res;
        console.log(res);
      }
    });
  }
}