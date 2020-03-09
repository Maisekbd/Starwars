import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './shared/home/home.component';
import { LoginComponent } from "./login/login.component";

import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { UnAuthorizedComponent } from './shared/unauthroized/unauthroized.component';

const routes: Routes = [
  //{
  //  path: '',
  //  component: LoginLayoutComponent,
  //  children: [
  //      { path: '', component: LoginComponent, pathMatch: 'full' },
  //      { path: 'login', component: LoginComponent, pathMatch: 'full' },
  //      { path: 'unauth', component: UnAuthorizedComponent, data: { title: 'unauth' } }
  //  ]
  //},
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'home', loadChildren: './shared/home/home.module#HomeModule' }
    ]
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
