import { Component, OnInit, HostBinding, ElementRef, OnDestroy, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { SharedService } from '../../services/shared.service';

import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, Observable, Subscription, of, timer } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  showHeader$: Observable<boolean>;


  private ShowHeader = new BehaviorSubject<boolean>(false);

  get showHeader() {
    return this.ShowHeader.asObservable();
  }
 
  notificationsSubscription: Subscription;
  timerSubscription: Subscription;
  private route: ActivatedRoute;
  /**Menu**/
  navbarOpen = false;

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }
  /**End of Menu**/
  fullInfo = "";
  surnames: string[];
  lastName = "";
  currentUser: string[];

  constructor(
    private translate: TranslateService,
    private el: ElementRef,
    public sharedService: SharedService,
    private router: Router) {
   
  }
  


  ngOnInit() {
    

  }
  useLanguage(language: string) {
    let prevLang = this.sharedService.getCurrentLanguage();
    this.sharedService.useLanguage(language);
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
    if (language == this.sharedService.appArLang) {
      this.el.nativeElement.closest('html').className = "rtl";
      this.sharedService.isRtlEmitter.next(true);
    }
    else {
      this.el.nativeElement.closest('html').classList.remove("rtl");
      this.sharedService.isRtlEmitter.next(false);
    }
    if (prevLang != this.sharedService.getCurrentLanguage())
      parent.document.location.reload();
  }

  signOut() {
  }
}

