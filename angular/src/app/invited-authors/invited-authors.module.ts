import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { InvitedAuthorsRoutingModule } from './invited-authors-routing.module';
import { InvitedAuthorsComponent } from './invited-authors.component';


@NgModule({
  declarations: [
    InvitedAuthorsComponent
  ],
  imports: [
    SharedModule,
    InvitedAuthorsRoutingModule
  ]
})
export class InvitedAuthorsModule { }
