import { Component, OnInit } from '@angular/core';
import { ICustomEvent } from '../list-item/list-item.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {
  users = [
    {
      firstName: 'Ivan',
      lastName: 'Ivanov'
    },
    {
      firstName: 'Pesho',
      lastName: 'Petrov'
    }
  ];

  selectedUserIndex: null | number = null;

  get showSelectedIndex(): boolean {
    return (this.selectedUserIndex === null ? -1 : this.selectedUserIndex) >= 0
  }

  showLastName = true;

  constructor() {
    
  }

  handleClickEvent() {
    this.showLastName = !this.showLastName;
  }

  listItemClickHandler(index: number) {
    if (this.selectedUserIndex === index) {
      this.selectedUserIndex = null;
      return;
    }
    this.selectedUserIndex = index;
  }

  customEventHandler($event: ICustomEvent) {
    console.log($event);
    
  }
}
