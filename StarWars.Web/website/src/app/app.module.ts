import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// import ngx-translate and the http loader
import { TranslateLoader, TranslateModule, TranslateStore } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
//import { EventEmiterService } from './services/eventEmiter.service';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

//import { AuthGuard } from './services/auth-guard.service';
import { JwtModule } from '@auth0/angular-jwt';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './login/login.component';
import { UnAuthorizedComponent } from './shared/unauthroized/unauthroized.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { AuthenticationService } from './services/authentication.service';
import { AppConfigModule } from './app-config.module';

import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';


import { NgxUiLoaderModule, NgxUiLoaderRouterModule, NgxUiLoaderHttpModule, NgxUiLoaderConfig, SPINNER, POSITION, PB_DIRECTION } from 'ngx-ui-loader';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  fgsColor: '#7ac142',
  pbColor: '#edd364',
  fgsPosition: POSITION.centerCenter,
  bgsPosition: POSITION.centerCenter,
  bgsColor: 'brown',
  fgsSize: 70,
  fgsType: SPINNER.wanderingCubes,
  pbDirection: PB_DIRECTION.rightToLeft, // progress bar direction
  pbThickness: 5, // progress bar thickness
};


@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    LoginLayoutComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    UnAuthorizedComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppConfigModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    }),
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig), // import NgxUiLoaderModule
    //NgxUiLoaderRouterModule,
    NgxUiLoaderHttpModule.forRoot({  }),
    AppRoutingModule,
    BsDropdownModule.forRoot(),
  ],
  providers: [

    //EventEmiterService,
    //AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})

export class AppModule { }



export function tokenGetter() {
  return localStorage.getItem('currentUser');
}
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}
