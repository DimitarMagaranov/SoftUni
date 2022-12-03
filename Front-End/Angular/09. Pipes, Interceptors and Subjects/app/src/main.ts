import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { BehaviorSubject, from, Observable, ReplaySubject, Subject } from "rxjs";

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

// const subj$$ = new Subject();

// subj$$.next(50);

// subj$$.subscribe(console.log);
// subj$$.subscribe(console.log);
// subj$$.subscribe(console.log);

// subj$$.next(100);
// subj$$.next(200);

// setTimeout(() => {
//   subj$$.next(500);
//   subj$$.subscribe(console.log);

//   setTimeout(() => {
//     subj$$.next(400);
//   }, 5000);
// }, 1000);



// const bSubject$$ = new BehaviorSubject(1);

// bSubject$$.subscribe(console.log);



// const rSubject$$ = new ReplaySubject(20);

// rSubject$$.next(100);
// rSubject$$.next(200);
// rSubject$$.next(300);

// rSubject$$.subscribe(console.log);

// rSubject$$.next(400);
// rSubject$$.next(500);
// rSubject$$.next(600);

// console.log('----');

// rSubject$$.subscribe(console.log);
