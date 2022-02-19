import {Guid} from "guid-typescript";

export class UserModel{

  private _id : Guid|undefined;
  private _nickname : string = '';
  private _email : string = '';
  private _password : string = '';
  private _userRole : number = 1;

  constructor(nickname : string, email : string, password : string, userRole : number) {
    this._nickname = nickname;
    this._email = email;
    this._password = password;
    this._userRole = userRole;
  }

  get id(): Guid|undefined {
    return this._id;
  }

  set id(value: Guid|undefined) {
    this._id = value;
  }

  get nickname(): string {
    return this._nickname;
  }

  set nickname(value: string) {
    this._nickname = value;
  }

  get email(): string {
    return this._email;
  }

  set email(value: string) {
    this._email = value;
  }

  get password(): string {
    return this._password;
  }

  set password(value: string) {
    this._password = value;
  }

  get userRole(): number {
    return this._userRole;
  }

  set userRole(value: number) {
    this._userRole = value;
  }
}
