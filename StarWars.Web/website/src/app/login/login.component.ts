import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm, FormBuilder, Validators, FormGroup } from '@angular/forms';

//import { AuthenticationService } from '../services/authentication.service';
import { first } from 'rxjs/operators';
//import { EventEmiterService } from '../services/eventEmiter.service';
import { Subscription } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TranslateService } from '@ngx-translate/core';
import { SharedService } from '../services/shared.service';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    invalidLogin: boolean;
    submitted: boolean = false;
    returnUrl: string;
    loginForm: FormGroup;
    sub: Subscription;

    constructor(
        private router: Router,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private jwtHelper: JwtHelperService,
        private route: ActivatedRoute,
        private authenticationService: AuthenticationService,
        private sharedService: SharedService,
        private translate: TranslateService,
    ) {
        document.body.className = "login-bg";

    }

    ngOnInit() {
        this.sharedService.useLanguage(this.sharedService.getCurrentLanguage());
        if (this.sharedService.getCurrentLanguage() == "ar") {
            document.body.className = "rtlDir"
        } else {
            document.body.className = "";
        }

        this.loginForm = this.formBuilder.group({
            username: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required]
        });

        //this.authenticationService.logout();
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home/viewEval';
    }

    login() {
        this.submitted = true;
        let credentials = JSON.stringify({ username: this.formData.username.value, password: this.formData.password.value });
        this.authenticationService.login(credentials)
            .pipe(first())
            .subscribe(
                data => {
                    if (!data) {
                        this.invalidLogin = false;
                        var token = localStorage.getItem("currentUser");
                        this.router.navigate([this.returnUrl]);
                    }
                    else {
                        this.invalidLogin = true;
                    }
                },
                error => {
                });
    }

    get formData() { return this.loginForm.controls; }

    ngOnDestroy() {
        document.body.className = "";
    }

}
