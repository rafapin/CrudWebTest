import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersListComponent } from './ui/pages/users-list/users-list.component';
import { UserDetailComponent } from './ui/dialogs/user-detail/user-detail.component';
import { IUserRepository, UserRepository } from '.';
import { SharedModule } from '../../shared/shared.module';
import { UsersStartComponent } from './ui/pages/users-start/users-start.component';


@NgModule({
  declarations: [
    UsersListComponent,
    UserDetailComponent,
    UsersStartComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    SharedModule,
  ],
  providers:[
    {provide: IUserRepository, useClass: UserRepository}
  ]
})
export class UsersModule { }
