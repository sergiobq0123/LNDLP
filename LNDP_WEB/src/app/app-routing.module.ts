import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [
  {
    path: '',
    component : HomeComponent,
  },
  {
    path : 'Login',
    component : LoginComponent,
  },
  {
    path : '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
