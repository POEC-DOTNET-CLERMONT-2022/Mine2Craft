import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {FurnaceDto} from "../../dtos/furnace-dto";
import {Observable} from "rxjs";
import {Guid} from "guid-typescript";
import {ItemDto} from "../../dtos/item-dto";

@Injectable({
  providedIn: 'root'
})
export class FurnaceService {

  baseUrl : string = 'https://localhost:7204/api/Furnace';

  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json-patch+json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  getFurnaceList(): Observable<FurnaceDto[]>{
    return this.httpClient.get<FurnaceDto[]>(this.baseUrl);
  }

  createFurnace(furnaceToCreate: { ItemBeforeCooking: ItemDto; ItemBeforeCookingId: Guid | undefined, ItemAfterCooking: ItemDto; ItemAfterCookingId: Guid | undefined}): Observable<number>{
    let furnaceAsJson = JSON.stringify(furnaceToCreate);
    return this.httpClient.post<number>(this.baseUrl, JSON.parse(furnaceAsJson), this.headers);
  }

  updateFurnace(furnaceToUpdate : FurnaceDto): Observable<string>{
    let furnaceAsJson = JSON.stringify(furnaceToUpdate)
    return this.httpClient.put<string>(this.baseUrl + "/" + furnaceToUpdate.id, JSON.parse(furnaceAsJson), this.headers);
  }

  deleteUser(id : Guid|undefined): Observable<number>{
    return this.httpClient.delete<number>(this.baseUrl + "/" + id);
  }
}
