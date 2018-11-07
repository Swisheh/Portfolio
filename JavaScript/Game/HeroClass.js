class Hero {
    constructor(name, race){
        this.name = name;
        this.race = race;
        this.equipedWeapon = {
            maxDamage: undefined,
            minDamage: undefined
        };
        this.skills = {
            attack: undefined,
            sneak: undefined,
            persuade: undefined
        };
        this.equipedArmor = {
            name: undefined,
            attackBarrierBonus: undefined
        };
        this.barriers = {
            attack: undefined,
            sneak: undefined,
            persuade: undefined
        };
    };

    setSkills(attack, sneak, persuade){
        this.skills.attack = attack;
        this.skills.sneak = sneak;
        this.skills.persuade = persuade;
    };
};

const name = prompt("Name your character:");
let race = prompt("Select a race from 'Human, Elf, Dward'").toLowerCase();


const start = function(name, race){
    if(race == 'human'){
        const player = new Hero (name, race);
        player.setSkills(0, 0, 1);
    } else if(race == 'elf'){
        const player = new Hero (name, race);
        player.setSkills(0, 1, 0);
    } else if(race == 'dwarf'){
        const player = new Hero (name, race);
        player.setSkills(1, 0, 0);
    } else {
        race = prompt("Race must be either 'Human, Elf, Dwarf'").toLowerCase();
        start(name, race);
    }
}

start(name, race);