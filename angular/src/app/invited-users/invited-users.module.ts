import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvitedUsersRoutingModule } from './invited-users-routing.module';
import { InvitedUsersComponent } from './invited-users.component';
import { NgSelectModule } from '@ng-select/ng-select';



@NgModule({
  declarations: [
    InvitedUsersComponent
  ],
  imports: [
    SharedModule,
    InvitedUsersRoutingModule,
    NgSelectModule
  ]
})
export class InvitedUsersModule { }
