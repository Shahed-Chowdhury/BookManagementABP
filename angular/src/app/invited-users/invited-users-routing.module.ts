import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvitedUsersComponent } from './invited-users.component';

const routes: Routes = [{ path: '', component: InvitedUsersComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvitedUsersRoutingModule { }
