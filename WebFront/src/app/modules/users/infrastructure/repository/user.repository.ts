import { inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpService } from '../../../../shared/services/http.service';
import { environment } from '../../../../../environments/enviroments';
import {User} from '@users/domain/user.interface'
import { IUserRepository } from '../../application';

@Injectable({
  providedIn: 'root'
})
export class UserRepository implements IUserRepository{
    http = inject(HttpService)
    baseUrl = environment.baseUrl+"/Users";
  Get(): Promise<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }
  Add(user: User): Promise<Boolean> {
    return this.http.post<User,Boolean>(this.baseUrl+"/add",user);
  }
  Update(user: User): Promise<Boolean> {
    return this.http.post<User,Boolean>(this.baseUrl+"/update",user);
  }
  ChangeStatus(userId:string,status:number): Promise<Boolean> {
    return this.http.post<any,Boolean>(this.baseUrl+"/changeStatus",{id: userId, status: status});
  }
}
