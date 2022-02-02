import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserDto} from "../../dtos/user-dto";
import {Observable} from "rxjs";
import {Guid} from "guid-typescript";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl : string = 'https://localhost:7204/api/User';

  constructor(private httpClient: HttpClient) { }

  getUserList(): Observable<UserDto[]>{
    return this.httpClient.get<UserDto[]>(this.baseUrl);
  }

  deleteUser(id : Guid|undefined): Observable<number>{
    return this.httpClient.delete<number>(this.baseUrl + "/" + id);
  }
}
