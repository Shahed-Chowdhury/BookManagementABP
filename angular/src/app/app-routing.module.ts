import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { 
    path: 'books',
    canActivate: [AuthGuard, PermissionGuard],
    loadChildren: () => import('./book/book.module').then(m => m.BookModule)
  },
  {
    path: 'authors',
    canActivate: [AuthGuard, PermissionGuard],
    loadChildren: () => import('./author/author.module').then(m => m.AuthorModule)
  },
  {
    path: 'publishers',
    canActivate: [AuthGuard, PermissionGuard],
    loadChildren: () => import('./publisher/publisher.module').then(m => m.PublisherModule)
  },
  { 
    path: 'invitedAuthors',
    canActivate: [AuthGuard, PermissionGuard],
    loadChildren: () => import('./invited-authors/invited-authors.module').then(m => m.InvitedAuthorsModule)
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
