import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeSectionWebComponent } from './components/web/home-section/home-section-web/home-section-web.component';
import { WebComponent } from './components/web/web.component';


const routes: Routes = [
  {
    path : 'Login',
    component : LoginComponent,
  },
  {
    path: 'Intranet',
    loadChildren: () => import('./components/intranet/intranet.module').then(m => m.IntranetModule),
    canActivate: [AuthGuard]
  },
  {
    path: '',
    component : WebComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./components/web/web.module').then((m) => m.WebModule),
      },
    ],
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
