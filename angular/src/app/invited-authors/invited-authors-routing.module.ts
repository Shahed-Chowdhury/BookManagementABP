import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvitedAuthorsComponent } from './invited-authors.component';

const routes: Routes = [{ path: '', component: InvitedAuthorsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvitedAuthorsRoutingModule { }
