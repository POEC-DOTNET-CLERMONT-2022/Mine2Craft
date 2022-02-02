import { Component, OnInit } from '@angular/core';
import {UserService} from "../../../services/user/user.service";
import {Observable} from "rxjs";
import {UserDto} from "../../../dtos/user-dto";
import Swal from 'sweetalert2'
import {Guid} from "guid-typescript";

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements OnInit {

  userList : UserDto[]|undefined;

  constructor(private userService : UserService) {
  }

  ngOnInit(): void {
    this.userService.getUserList()
      .subscribe((userList : UserDto[] ) => {
        this.userList = userList;
      })
  }

  updateUser(user: UserDto) {
    Swal.fire({
      title : 'Modification du role de : ' + user.nickname,
      html:
        '<label>Pseudo :</label>'+
        '<input id="swal-input1" class="swal2-input" value="' + user.nickname + '">' +
        '<label>Email :</label>'+
        '<input id="swal-input2" class="swal2-input" value="' + user.email + '">',
    })
  }

  deleteUser(id : Guid|undefined) {
    Swal.fire({
      title: "Suppresion d'un utilisateur !",
      text: 'Êtes-vous sûr de vouloir supprimer cet utilisateur ?',
      icon: 'warning',
      confirmButtonText: 'For sure !',
      confirmButtonColor: '#33dd36',
      showCancelButton: true,
      cancelButtonText: 'Nope bitch !',
      cancelButtonColor: '#d33',
    }).then((result) => {
      if (result.isConfirmed) {
        this.userService.deleteUser(id)
          .subscribe((rawAffected : number) => {
            if(rawAffected === 1){
              Swal.fire({
                title : 'Confirmation de suppresion !',
                text : "L'utilisateur a été supprimé avec succès",
                icon : 'success'
              });
              this.userList = this.userList?.filter((user) => user.id != id);
            }else{
              Swal.fire({
                title: 'Erreur lors de la suppresion',
                text: "Une erreur est survenue lors de la suppression",
                icon: 'error'
              });
            }
          });
      }
    })
  }
}
