import { User } from "@users/domain";

export abstract class IUserRepository {
    abstract Get(): Promise<User[]>;
    abstract Add(user: User): Promise<Boolean>;
    abstract Update(user: User): Promise<Boolean>;
    abstract ChangeStatus(userId:string,status:number): Promise<Boolean>;
}