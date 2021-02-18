function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let input = document.getElementsByTagName('textarea')[0];

   function onClick () {
      let inputArray = JSON.parse(input.value);
      let restaurants = {};
      
      for(let  i = 0; i < inputArray.length; i++) {
         const tokens = inputArray[i].split(' - ');
         const name = tokens[0];
         const workers = tokens[1].split(', ');
         let workersObjects = [];

         for(let j = 0; j < workers.length; j++) {
            const currWorker = workers[j].split(' ');
            const workerName = currWorker[0];
            const workerSalary = Number(currWorker[1]);

            workersObjects.push({workerName, workerSalary});
         }

         if(restaurants[name]) {
            workersObjects = workersObjects.concat(restaurants[name].workers);
         }

         workersObjects.sort((worker1, worker2) => worker2.workerSalary - worker1.workerSalary);
         
         const bestSalary = workersObjects[0].workerSalary;
         const sumOfAllSalaries = workersObjects.reduce((sum, worker) => sum + worker.workerSalary, 0);
         const averageSalary = (sumOfAllSalaries / workersObjects.length);

         restaurants[name] = {
            workers: workersObjects,
            bestSalary,
            averageSalary,
         }
      }

      let bestRestaurant = undefined;
      let bestRestaurantName = '';
      let bestRestaurantSalary = 0;

      for(const name in restaurants) {
         if(restaurants[name].averageSalary > bestRestaurantSalary) {
            bestRestaurantSalary = (restaurants[name].averageSalary);
            bestRestaurant = restaurants[name];
            bestRestaurantName = name;
         }
      }

      let bestRestParagraph = `Name: ${bestRestaurantName} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${(bestRestaurant.bestSalary.toFixed(2))}`;

      document.querySelector('#bestRestaurant p').textContent = bestRestParagraph;
      
      let workersParagraph = '';

      for(let worker of bestRestaurant.workers) {
         workersParagraph += `Name: ${worker.workerName} With Salary: ${(worker.workerSalary)} `;
      }
      
      document.querySelector('#workers p').textContent = workersParagraph.trim();
   }
}