const object = {
    name: "Rory",
    age: 27,
    gender: "male"
};

const sayName = function(name){
    return "Hello! My name is " + name + '.';
};

const oneYearOlder = function(age){
    return age++;
};


const sumOfNumbers = function(array){
    let sum = 0;
    array.forEach(element => {
        sum = sum + element;
    });
    return sum;
}