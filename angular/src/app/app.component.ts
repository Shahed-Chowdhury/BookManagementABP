import { Component } from '@angular/core';
import { AuthService } from '@abp/ng.core';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent {
  constructor(private oAuthService: OAuthService, private authService: AuthService) {
    if (window.location.href == environment.oAuthConfig.redirectUri + '/?force_redirect=true') {
      this.authService.navigateToLogin();
    }
  }
}
