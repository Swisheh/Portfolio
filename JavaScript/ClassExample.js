class Monster {
    constructor(name){
        this.name = name;
    };

    found(){
        console.log("You stumble upon a " + this.name);
    }

}

class Wolf extends Monster {
    constructor(name){
        super(name);
        this.type = "Wolf";
    };

    found(){
        console.log("You hear a growling nearby. Must be a " + this.type);
        super.found();
    }

}