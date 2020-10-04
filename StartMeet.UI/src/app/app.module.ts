import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule , FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './home/registration/registration.component';
import { LoginComponent } from './home/login/login.component';
import { DescriptionComponent } from './home/description/description.component';
import { UserAuthenticationService } from "./home/shared/user-authentication.service";
import { UserPageComponent } from './user-page/user-page.component';
import { NavigationBarComponent } from './user-page/navigation-bar/navigation-bar.component';
import { UserService } from './user-page/shared/user.service';
import { AuthInterceptor } from "./auth/auth.interceptor";
import { UserSettingsComponent } from './user-page/user-settings/user-settings.component';
import { SettingsListComponent } from './user-page/user-settings/settings-list/settings-list.component';
import { UserPropertiesListComponent } from './user-page/user-settings/user-properties-list/user-properties-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    DescriptionComponent,
    UserPageComponent,
    NavigationBarComponent,
    UserSettingsComponent,
    SettingsListComponent,
    UserPropertiesListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule
  ],
  providers: [UserAuthenticationService, UserService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
