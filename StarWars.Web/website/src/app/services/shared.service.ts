import { Injectable, Inject, HostBinding, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subject, BehaviorSubject, Subscription } from 'rxjs';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { filter } from 'rxjs/operators';
import { tap, map } from 'rxjs/operators';
import { Title } from '@angular/platform-browser';



@Injectable({ providedIn: 'root' })

export class SharedService {
  public appArLang: string = 'ar';
  public appEnLang: string = 'en';


  @HostBinding('attr.dir') direction = "rtl";
  locale: string = localStorage.getItem('lang');
  langChangeSubscription: Subscription;
  isRtlEmitter = new BehaviorSubject<boolean>(false);
  serviceUrl = `${this.config.apiEndpoint}`;
  rtlEnabled: boolean = true;



/*----- DataSource URL-------------*/
    public OpportunitiesDSUrl: string = "/Opportunity/Get";
  
  /*----- End Customer URL-------------*/


  constructor(
    private translate: TranslateService,
    @Inject(APP_CONFIG) private config: AppConfig,
    private httpClient: HttpClient,
    private titleService: Title) {
    this.useLanguage(this.getCurrentLanguage() || this.appArLang);

  }

  useLanguage(language: string) {
    this.setCurrentLanguage(language)
   // loadMessages((language == this.appArLang) ? messagesAr : MessagesEn);
    this.titleService.setTitle(language == this.appArLang ? "تقييم الفرص الاستثمارية" : "Investment Opportunity  Evaluation");
    this.rtlEnabled = (language == this.appArLang) ? true : false;
    this.translate.use(language);
  }

  getCurrentLanguage() {
    return localStorage.getItem('lang');
  }

  setCurrentLanguage(language: string) {
    localStorage.setItem('lang', language);
  }

  onBeforeSend(method, ajaxOptions) {
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    ajaxOptions.headers = { Authorization: `Bearer ${currentUser.token}` };
  }





}
