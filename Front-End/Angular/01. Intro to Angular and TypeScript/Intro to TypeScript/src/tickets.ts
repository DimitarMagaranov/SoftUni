class Ticket {
  destination: string;
  price: number;
  status: string;

  constructor(destination: string, price: number, status: string) {
    this.destination = destination;
    this.price = price;
    this.status = status;
  }
}

function getSortedTickets(tickets: string[], criteria: string): Ticket[] {
  const result = new Array<Ticket>();

  tickets.forEach((ticket) => {
    const tokens = ticket.split("|");
    const destination = tokens[0];
    const price = Number(tokens[1]);
    const status = tokens[2];

    const newTicket = new Ticket(destination, price, status);
    result.push(newTicket);
  });

  switch (criteria) {
    case "destination": {
      result.sort((a, b) => a.destination.localeCompare(b.destination));
      break;
    }
    case "price": {
      result.sort((a, b) => a.price - b.price);
      break;
    }
    case "status": {
      result.sort((a, b) => a.status.localeCompare(b.status));
      break;
    }
  }
  return result;
}

console.log(
  getSortedTickets(
    [
      "Philadelphia|94.20|available",

      "New York City|95.99|available",

      "New York City|95.99|sold",

      "Boston|126.20|departed",
    ],

    "status"
  )
);
