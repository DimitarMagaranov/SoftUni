function solve(arrayOfTickets, sortCriteria) {
    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    for(let ticketInput of arrayOfTickets) {
        const tokens = ticketInput.split('|');
        const destination = tokens[0];
        const price = Number(tokens[1]);
        const status = tokens[2];

        const ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    if(sortCriteria === 'destination') {
        return tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if(sortCriteria === 'status') {
        return tickets.sort((a, b) => a.status.localeCompare(b.status));
    } else if(sortCriteria === 'price') {
        return tickets.sort((a, b) => a.price - b.price);
    }
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));