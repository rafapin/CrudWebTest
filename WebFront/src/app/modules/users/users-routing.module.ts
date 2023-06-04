import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersListComponent } from './ui/pages/users-list/users-list.component';
import { UsersStartComponent } from './ui/pages/users-start/users-start.component';

const routes: Routes = [
  {
    path: '',
    component: UsersStartComponent,
  },
  {
    path: 'users',
    component: UsersListComponent,
  },
  {
      path: '**',
      redirectTo: 'users',
      pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
