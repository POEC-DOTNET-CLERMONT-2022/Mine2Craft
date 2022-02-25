import { Guid } from 'guid-typescript';

export class ItemDto {

  private _id : Guid|undefined;
  private _name : string;
  private _description : string;
  private _isCombustible : boolean;
  private _isCooked : boolean;
  private _imagePath : string;

  constructor(name: string, description: string, isCombustible: boolean, isCooked: boolean, imagePath: string) {
    this._name = name;
    this._description = description;
    this._isCombustible = isCombustible;
    this._isCooked = isCooked;
    this._imagePath = imagePath;
  }

  get id(): Guid | undefined {
    return this._id;
  }

  set id(value: Guid | undefined) {
    this._id = value;
  }

  get name(): string {
    return this._name;
  }

  set name(value: string) {
    this._name = value;
  }

  get description(): string {
    return this._description;
  }

  set description(value: string) {
    this._description = value;
  }

  get isCombustible(): boolean {
    return this._isCombustible;
  }

  set isCombustible(value: boolean) {
    this._isCombustible = value;
  }

  get isCooked(): boolean {
    return this._isCooked;
  }

  set isCooked(value: boolean) {
    this._isCooked = value;
  }

  get imagePath(): string {
    return this._imagePath;
  }

  set imagePath(value: string) {
    this._imagePath = value;
  }
}
