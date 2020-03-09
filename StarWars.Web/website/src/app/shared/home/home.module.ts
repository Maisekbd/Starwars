import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from '../shared.module';
import { Routes, RouterModule } from '@angular/router';
import { ArchwizardModule } from 'angular-archwizard';
import { GroupByPipe } from '../../pipes/groupBy.pipe';


@NgModule({
  declarations: [
    HomeComponent,
    GroupByPipe
  ],
  imports: [
    SharedModule,
    HomeRoutingModule,
    ArchwizardModule
  ],
  entryComponents: [
  ],
  providers: [],
})
export class HomeModule { }


