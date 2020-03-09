
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormGroup, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { A11yModule } from '@angular/cdk/a11y';
//import { PortalModule } from '@angular/cdk/portal';
//import { ScrollingModule } from '@angular/cdk/scrolling';

//import { CdkTableModule } from '@angular/cdk/table';

//import { MatTabsModule } from '@angular/material/tabs';
//import { MatStepperModule } from '@angular/material/stepper';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AccordionModule } from 'ngx-bootstrap/accordion';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedService } from '../services/shared.service';

@NgModule({
  declarations: [/*DisableControlDirective*/],
  imports: [
    //A11yModule,
    //MatStepperModule,
    //CdkTableModule,
    //PortalModule,
    //ScrollingModule
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: false
    }),
   
    CollapseModule.forRoot(),
    AccordionModule.forRoot(),
  ],
  //providers: [
  //  AuthGuard,
  //  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  //  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  //],
  exports: [
    //A11yModule,
    //MatStepperModule,
    //CdkTableModule,
    //PortalModule,
    //ScrollingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    //CollapseModule,
    AccordionModule
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [{ provide: SharedService }]
    }
  }
}

export function tokenGetter() {
  return localStorage.getItem('currentUser');
}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
