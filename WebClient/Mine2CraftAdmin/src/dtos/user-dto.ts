import { Guid } from 'guid-typescript';

export class UserDto{

  private _id : Guid|undefined;
  private _nickname : string = '';
  private _email : string = '';

  constructor() {
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
}
