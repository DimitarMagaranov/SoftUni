function gcdTwoNumbers(x, y) {
    while(y !== 0) {
      let temp = y;
      y = x % y;
      x = temp;
    }
    return x;
  }
  
  console.log(gcdTwoNumbers(15, 5));
  console.log(gcdTwoNumbers(9, 3));
  