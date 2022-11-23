import { Component, OnInit, Provider } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}





class TheTestClass {
  constructor(private router: Router) {}
}

// if we want separate instance of the class in the compoenent where is injected
export const myProvider: Provider = {
  provide: TheTestClass,
  useFactory: (router: Router) => {
    return new TheTestClass(router);
  },
  deps: [Router]
}