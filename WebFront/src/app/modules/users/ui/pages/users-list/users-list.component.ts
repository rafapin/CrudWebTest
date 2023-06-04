import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IUserRepository } from '@users/application';
import { User } from '@users/domain';
import { UserDetailComponent } from '@users/ui/dialogs';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss'],
  animations: [
    trigger('fadeInOut', [
      state('void', style({ opacity: 0 })),
      transition(':enter, :leave', [
        animate(2000)
      ])
    ])
  ]
})
export class UsersListComponent {
  userRepository = inject(IUserRepository)
  dialog = inject(MatDialog)
  displayedColumns: string[] = ['id', 'userName', 'email','status','options'];
  users:User[] = []
  ngOnInit():void {
    this.getUsers();
  }
  getUsers():void{
    this.userRepository.Get().then(response=>{
      this.users = response;
    })
  }
  openFormUser(user:User|null):void{
    const dialogRef = this.dialog.open(UserDetailComponent,{ data: {...user}, width:'50%'});
    dialogRef.afterClosed().subscribe(_=>{
      this.getUsers();
    })
  }
  onToogle(event:any, user:User){
    let status= event.checked ? 1 : 0
    this.userRepository.ChangeStatus(user.id,status).then(_=>{
      this.getUsers();
    })
  }
}
