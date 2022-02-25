import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {UserDto} from "../../dtos/user-dto";
import {Observable} from "rxjs";
import {Guid} from "guid-typescript";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl : string = 'https://localhost:7204/api/User';

  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json-patch+json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  getUserList(): Observable<UserDto[]>{
    return this.httpClient.get<UserDto[]>(this.baseUrl);
  }

  createUser(userToCreate: { Email: string; Nickname: string, Password: string}): Observable<number>{
    let userAsJson = JSON.stringify(userToCreate);
    console.log(JSON.parse(userAsJson));

    return this.httpClient.post<number>(this.baseUrl, JSON.parse(userAsJson), this.headers);
  }

  updateUser(userToUpdate : UserDto): Observable<boolean>{
    let userAsJson = JSON.stringify(userToUpdate);

    return this.httpClient.put<boolean>(this.baseUrl + "/" + userToUpdate.id, JSON.parse(userAsJson), this.headers);
  }

  deleteUser(id : Guid|undefined): Observable<number>{
    return this.httpClient.delete<number>(this.baseUrl + "/" + id);
  }
}