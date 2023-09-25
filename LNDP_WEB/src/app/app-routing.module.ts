import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';


const routes: Routes = [
  {
    path : 'Login',
    component : LoginComponent,
  },
  {
    path: 'Intranet',
    loadChildren: () => import('./components/intranet/intranet.module').then(m => m.IntranetModule)
  },
  {
    path: '',
    component : HomeComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./components/web/web.module').then((m) => m.WebModule),
      },
    ],
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
