import { Component, OnInit } from '@angular/core';
import {FurnaceService} from "../../../services/furnace/furnace.service";
import {Observable, subscribeOn} from "rxjs";
import {FurnaceDto} from "../../../dtos/furnace-dto";
import Swal from 'sweetalert2'
import {Guid} from "guid-typescript";
import {ItemDto} from "../../../dtos/item-dto";
import {ItemService} from "../../../services/item/item.service";

@Component({
  selector: 'app-furnace-management',
  templateUrl: './furnace-management.component.html',
  styleUrls: ['./furnace-management.component.scss']
})
export class FurnaceManagementComponent implements OnInit {

  furnaceList : FurnaceDto[] = [];
  itemList : ItemDto[] = [];
  itemNotInFurnace: ItemDto[] = [];

  constructor(private furnaceService : FurnaceService, private itemService : ItemService) {
  }

  ngOnInit(): void {
    this.furnaceService.getFurnaceList()
      .subscribe((furnaceList : FurnaceDto[] ) => {
        this.furnaceList = furnaceList;

        this.itemService.getItemList()
          .subscribe((itemList : ItemDto[]) => {
            this.itemList = itemList;

            for(let i = 0; i < itemList.length; i++){
              if(!(furnaceList.some(furnace => furnace.itemBeforeCookingId === itemList[i].id)) && !(furnaceList.some(furnace => furnace.itemAfterCookingId === itemList[i].id))){
               if(itemList[i].isCooked){
                 this.itemNotInFurnace.push(itemList[i]);
               }
              }
            }

          });

      });
  }

  createFurnace() {

    let map = new Map<Guid | undefined, string>();

    for(let i = 0; i < this.itemNotInFurnace.length; i++){
      map.set(this.itemNotInFurnace[i].id, this.itemNotInFurnace[i].name);
    }

    let itemBeforeCookingSelected : ItemDto;
    let itemAfterCookingSelected : ItemDto;

    Swal.fire({
      input: "select",
      inputAttributes: {
        id: "dropdownItemBeforeCooking",
      },
      inputOptions: map,
      inputValidator: function (value) {
        return new Promise(function (resolve, reject) {
          if (value != null) {
            // @ts-ignore
            resolve()
          }
        })
      }
    }).then((result) => {
      if(result.isConfirmed){
        let itemBeforeCookingSelectedIndex = this.itemNotInFurnace.findIndex(itemDto => itemDto.id === result.value)
        itemBeforeCookingSelected = this.itemNotInFurnace[itemBeforeCookingSelectedIndex];

        Swal.fire({
          input: "select",
          inputAttributes: {
            id: "dropdownItemAfterCooking",
          },
          inputOptions: map,
          inputValidator: function (value) {
            return new Promise(function (resolve, reject) {
              if (value != null) {
                // @ts-ignore
                resolve()
              }
            })
          }
        }).then((result) => {
          if(result.isConfirmed){
            let itemAfterCookingSelectedIndex = this.itemNotInFurnace.findIndex(itemDto => itemDto.id === result.value)
            itemAfterCookingSelected = this.itemNotInFurnace[itemAfterCookingSelectedIndex];

            if(itemBeforeCookingSelected != null && itemAfterCookingSelected){
              let furnace = {
                ItemBeforeCooking : itemBeforeCookingSelected,
                ItemBeforeCookingId: itemBeforeCookingSelected.id,
                ItemAfterCooking: itemAfterCookingSelected,
                ItemAfterCookingId: itemAfterCookingSelected.id,
              }

              this.furnaceService.createFurnace(furnace)
                .subscribe((creationSucceed : number) => {
                  if(creationSucceed === 1){
                    Swal.fire({
                      title : 'Confirmation de modification !',
                      text : "Le role de l'utilisateur a ??t?? mis ?? jour avec succ??s",
                      icon : 'success'
                    });

                    this.furnaceService.getFurnaceList()
                      .subscribe((furnaceList : FurnaceDto[] ) => {
                        this.furnaceList = furnaceList;
                      });

                    let itemBeforeCookingIndex = this.itemNotInFurnace.findIndex(item => item.id === itemBeforeCookingSelected.id);

                    this.itemNotInFurnace.splice(itemBeforeCookingIndex, 1);

                    let itemAfterCookingIndex = this.itemNotInFurnace.findIndex(item => item.id === itemAfterCookingSelected.id);

                    this.itemNotInFurnace.splice(itemAfterCookingIndex, 1);
                  }else{
                    Swal.fire({
                      title: 'Erreur lors de la modification',
                      text: "Une erreur est survenue lors de la modification du role",
                      icon: 'error'
                    });
                  }
                });

            }
          }
        });
      }
    });

  }

  updateFurnace(furnace: FurnaceDto) {

    let map = new Map<Guid | undefined, string>();

    for(let i = 0; i < this.itemNotInFurnace.length; i++){
      map.set(this.itemNotInFurnace[i].id, this.itemNotInFurnace[i].name);
    }

    let itemBeforeCookingSelected : ItemDto | undefined;
    let itemAfterCookingSelected : ItemDto | undefined;

    Swal.fire({
      input: "select",
      inputAttributes: {
        id: "dropdownItemBeforeCooking",
      },
      inputOptions: map,
      inputValidator: function (value) {
        return new Promise(function (resolve, reject) {
          if (value != null) {
            // @ts-ignore
            resolve()
          }
        })
      },
      showCancelButton: true,
    }).then((result) => {
      if(result.isConfirmed){
        itemBeforeCookingSelected = this.itemNotInFurnace.find(itemDto => itemDto.id === result.value)
      }

      Swal.fire({
        input: "select",
        inputAttributes: {
          id: "dropdownItemAfterCooking",
        },
        inputOptions: map,
        inputValidator: function (value) {
          return new Promise(function (resolve, reject) {
            if (value != null) {
              // @ts-ignore
              resolve()
            }
          })
        },
        showCancelButton: true,
      }).then((result) => {
        if(result.isConfirmed){
          itemAfterCookingSelected = this.itemNotInFurnace.find(itemDto => itemDto.id === result.value)
        }

        Swal.fire({
          title: '??tes vous s??r de vouloir modifier cette relation ?',
          showCancelButton: true,
        }).then((result) => {
            if(result.isConfirmed){

              if(itemBeforeCookingSelected === undefined){
                itemBeforeCookingSelected = furnace.itemBeforeCooking;
              }else{
                let itemBeforeCookingSelectedIndex = this.itemNotInFurnace.findIndex(item => {
                  if(itemBeforeCookingSelected != undefined){
                    return item.id === itemBeforeCookingSelected.id;
                  }
                  return null;
                });

                if(itemBeforeCookingSelectedIndex != null){
                  this.itemNotInFurnace.splice(itemBeforeCookingSelectedIndex, 1);
                }

                this.itemNotInFurnace.push(furnace.itemBeforeCooking);
              }

              if(itemAfterCookingSelected === undefined){
                itemAfterCookingSelected = furnace.itemAfterCooking;
              }else{
                let itemAfterCookingSelectedIndex = this.itemNotInFurnace.findIndex(item => {
                  if(itemAfterCookingSelected != undefined){
                    return item.id === itemAfterCookingSelected.id;
                  }
                  return null;
                });

                if(itemAfterCookingSelectedIndex != null){
                  this.itemNotInFurnace.splice(itemAfterCookingSelectedIndex, 1);
                }

                this.itemNotInFurnace.push(furnace.itemAfterCooking);
              }


              if(itemBeforeCookingSelected != null && itemAfterCookingSelected != null){
                furnace.itemBeforeCookingId = itemBeforeCookingSelected.id;
                furnace.itemBeforeCooking = itemBeforeCookingSelected;

                furnace.itemAfterCookingId = itemAfterCookingSelected.id;
                furnace.itemAfterCooking = itemAfterCookingSelected;


                this.furnaceService.updateFurnace(furnace)
                  .subscribe((modificationSucceed : string) => {
                    if(modificationSucceed === 'True'){
                      Swal.fire({
                        title : 'Confirmation de modification !',
                        text : "Le role de l'utilisateur a ??t?? mis ?? jour avec succ??s",
                        icon : 'success'
                      });
                    }else{
                      Swal.fire({
                        title: 'Erreur lors de la modification',
                        text: "Une erreur est survenue lors de la modification du role",
                        icon: 'error'
                      });
                    }
                  });
              }
            }
        });
      });
    });
  }

  deleteFurnace(id : Guid|undefined) {
    Swal.fire({
      title: "Suppresion d'un utilisateur !",
      text: '??tes-vous s??r de vouloir supprimer cet utilisateur ?',
      icon: 'warning',
      confirmButtonText: 'For sure !',
      confirmButtonColor: '#33dd36',
      showCancelButton: true,
      cancelButtonText: 'Nope bitch !',
      cancelButtonColor: '#d33',
    }).then((result) => {
      if (result.isConfirmed) {
        this.furnaceService.deleteUser(id)
          .subscribe((rawAffected : number) => {
            if(rawAffected === 1){
              Swal.fire({
                title : 'Confirmation de suppresion !',
                text : "L'utilisateur a ??t?? supprim?? avec succ??s",
                icon : 'success'
              });

              let furnaceIndex = this.furnaceList.findIndex(furnace => furnace.id === id);
              let furnace = this.furnaceList[furnaceIndex];

              this.furnaceList.splice(furnaceIndex, 1);

              let itemBeforeCookingIndex = this.itemList.findIndex(item => item.id === furnace.itemBeforeCooking.id);
              let itemBeforeCooking = this.itemList[itemBeforeCookingIndex];
              this.itemNotInFurnace.push(itemBeforeCooking)

              let itemAfterCookingIndex = this.itemList.findIndex(item => item.id === furnace.itemAfterCooking.id);
              let itemAfterCooking = this.itemList[itemAfterCookingIndex];
              this.itemNotInFurnace.push(itemAfterCooking)

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

  convertRoleToString(userRole: number) : string {
    if(userRole === 1){
      return "Administrateur";
    }
    return "Super Administrateur";
  }
}
