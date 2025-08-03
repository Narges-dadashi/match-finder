import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/account/register/register.component';
import { LoginComponent } from './components/account/login/login.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { MemberComponent } from './components/member/member.component';
import { authGuard } from './guards/auth.guard';
import { authLoggedInGuard } from './guards/auth-logged-in.guard';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'account/register', component: RegisterComponent, canActivate: [authLoggedInGuard] },
    { path: 'account/login', component: LoginComponent, canActivate: [authLoggedInGuard] },
    { path: 'footer', component: FooterComponent },
    { path: 'navbar', component: NavbarComponent },
    { path: 'members', component: MemberComponent, canActivate: [authGuard] },
    { path: '**', component: NotFoundComponent }
];