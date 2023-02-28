import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvitedUsersRoutingModule } from './invited-users-routing.module';
import { InvitedUsersComponent } from './invited-users.component';


@NgModule({
  declarations: [
    InvitedUsersComponent
  ],
  imports: [
    SharedModule,
    InvitedUsersRoutingModule
  ]
})
export class InvitedUsersModule { }
