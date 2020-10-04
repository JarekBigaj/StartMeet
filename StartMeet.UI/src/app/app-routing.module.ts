import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AuthGuard } from './auth/auth.guard'
import { UserSettingsComponent } from './user-page/user-settings/user-settings.component';


const routes: Routes = [
  {path:'',redirectTo:'home', pathMatch:'full'},
  {path:'home', component:HomeComponent},
  {
    path:'userpage',component:UserPageComponent, canActivate:[AuthGuard],
    children:[
      {path:'UserSettings', component: UserSettingsComponent}
    ]
    
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
