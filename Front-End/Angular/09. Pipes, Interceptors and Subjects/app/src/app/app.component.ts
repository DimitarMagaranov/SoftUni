import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

function add(a: number | string, b : number | string) {
  return a as any + b as any;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  add = add;

  username = 'Magaranov'; 
  obj = {
    scores: [1, 2, 3, 4, 5],
  };

  users$ = this.userService.users$;
  isLoadingUsers$ = this.userService.isLoading$;

  constructor(private userService: UserService) {

  }

  loadUsersHandler(): void {
    this.userService.loadUsers();
  }

  calcScores(obj: { scores: number[] }) {
    return obj.scores.reduce((a, c) => a + c);
  }

  addProp() {
    (this.obj as any)['test'] = 500;
  }


  // myPromise = new Promise((res) => {
  //   setTimeout(() => {
  //     res('HEY');
  //   }, 3000);
  // });

  // ngOnInit(): void {
  //   this.userService.getUsers().subscribe({
  //     next: users => console.log(users),
  //     error: err => console.error(err)
  //   })
  // }
}
