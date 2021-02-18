function solve(person) {
    if(person.dizziness == true) {
        let waterToIntake = (0.1 * person.weight * person.experience) + person.levelOfHydrated;

        person.levelOfHydrated = waterToIntake;
        person.dizziness = false;
    }

    return person;
}

console.log(solve({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  
  ));