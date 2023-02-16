import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }

  constructor(private oAuthService: OAuthService, private authService: AuthService) {
    if (window.location.href == environment.oAuthConfig.redirectUri + '/?force_redirect=true') {
      this.authService.navigateToLogin();
    }
    if(!this.hasLoggedIn){
      this.authService.navigateToLogin();

    }
  }

  login() {
    this.authService.navigateToLogin();
  }
}
