import { Guid } from 'guid-typescript';
import {ItemDto} from "./item-dto";

export class FurnaceDto {

  private _id : Guid|undefined;
  private _itemBeforeCookingId : Guid|undefined;
  private _itemBeforeCooking : ItemDto;
  private _itemAfterCookingId : Guid|undefined;
  private _itemAfterCooking : ItemDto;

  constructor(itemBeforeCookingId: Guid | undefined, itemBeforeCooking: ItemDto, itemAfterCookingId: Guid | undefined, itemAfterCooking: ItemDto) {
    this._itemBeforeCookingId = itemBeforeCookingId;
    this._itemBeforeCooking = itemBeforeCooking;
    this._itemAfterCookingId = itemAfterCookingId;
    this._itemAfterCooking = itemAfterCooking;
  }

  get id(): Guid | undefined {
    return this._id;
  }

  set id(value: Guid | undefined) {
    this._id = value;
  }

  get itemBeforeCookingId(): Guid | undefined {
    return this._itemBeforeCookingId;
  }

  set itemBeforeCookingId(value: Guid | undefined) {
    this._itemBeforeCookingId = value;
  }

  get itemBeforeCooking(): ItemDto {
    return this._itemBeforeCooking;
  }

  set itemBeforeCooking(value: ItemDto) {
    this._itemBeforeCooking = value;
  }

  get itemAfterCookingId(): Guid | undefined {
    return this._itemAfterCookingId;
  }

  set itemAfterCookingId(value: Guid | undefined) {
    this._itemAfterCookingId = value;
  }

  get itemAfterCooking(): ItemDto {
    return this._itemAfterCooking;
  }

  set itemAfterCooking(value: ItemDto) {
    this._itemAfterCooking = value;
  }
}
