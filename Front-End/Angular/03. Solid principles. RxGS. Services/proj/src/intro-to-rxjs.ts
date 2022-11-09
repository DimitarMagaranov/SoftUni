import {Observable, map} from 'rxjs';

function interval(intervalValue: number = 0) {
  return new Observable<number>(observer => {
    let couner = 0;
    const timerId = setInterval(() => {
      observer.next(couner++);
    }, intervalValue);
    return () => {
      clearInterval(timerId);
    }
  });
};

const stream$ = interval(5000).pipe(
  map(x => x + 1),
  map(x => x + 1),
  map(x => x + 1)
  );

  setTimeout(() => {
    const sub = stream$.subscribe(console.log);

    setTimeout(()=> {
      sub.unsubscribe();
    }, 5000)
  }, 3000);