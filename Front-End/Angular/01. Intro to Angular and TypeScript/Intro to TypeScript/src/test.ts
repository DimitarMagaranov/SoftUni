let username = 'Pesho';

console.log(username);




function createUser (username: string) {
    return {
        username
    };
};

const ivan = createUser('Ivan');




let isOpen: boolean = false;
isOpen = true;




function genFunc<T>(item: T): T {
    return item;
}
const num = genFunc(1);




interface MyDto {
    prop: string,
    prop1: number
};
type MyDtoOrNumber = MyDto | number;
type BooleanArray = boolean[];
let num2 = genFunc<MyDto>({prop: '1', prop1: 1});
let num3 = genFunc<MyDtoOrNumber>({prop: '1', prop1: 1});
let num4 = genFunc<MyDtoOrNumber>(1);