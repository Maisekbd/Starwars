import { Component, OnInit } from '@angular/core';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss']
})
export class LoginLayoutComponent implements OnInit {

    constructor(private ngxService: NgxUiLoaderService, ) { }

    ngOnInit() {
        this.ngxService.start(); // start foreground loading with 'default' id
        setTimeout(() => {
            this.ngxService.stop(); // stop foreground loading with 'default' id
        }, 4000);

    }

}
