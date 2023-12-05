import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PromocoesComponent } from './promocoes/promocoes.component';

export const routes: Routes = 
[
    {path: '', component: LoginComponent},
    {path: 'promocoes', component: PromocoesComponent}
];
