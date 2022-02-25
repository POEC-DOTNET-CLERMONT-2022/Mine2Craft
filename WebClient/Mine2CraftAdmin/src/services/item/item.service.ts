import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {FurnaceDto} from "../../dtos/furnace-dto";
import {ItemDto} from "../../dtos/item-dto";

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  baseUrl : string = 'https://localhost:7204/api/Item';

  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json-patch+json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  getItemList(): Observable<ItemDto[]>{
    return this.httpClient.get<ItemDto[]>(this.baseUrl);
  }
}
