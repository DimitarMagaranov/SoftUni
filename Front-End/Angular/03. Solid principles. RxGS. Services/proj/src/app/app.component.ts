import { Component, Inject } from '@angular/core';
import { MyClass } from './app.module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  counter = 0;
  users = [
    {
      name: 'Ivan'
    },
    {
      name: 'Pesho'
    }
  ]
  constructor(
    // @Inject('Test') test: string
    // @Inject(MyClass) test: MyClass -->
    //test: MyClass
    ) {

    //console.log(test);
    
    
    // setInterval(() => {
    //   this.counter++;
    // }, 3000)
  }

  addUserHandler (nameInput: HTMLInputElement): void {
    const {value} = nameInput;
    this.users = this.users.concat({name: value});
    nameInput.value = '';
  }
}
