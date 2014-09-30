var seedrandom = require('seedrandom');



function randomSeed(rnd, min, max) {
    var rng = seedrandom('hello.');

    if(typeof max === 'undefined') {
        max = min;
        min = 0;
    }
    return ((max - min) / 1 * rnd()) | 0
}

console.log(randomSeed(rng, 50));
console.log(randomSeed(rng, 50));
console.log(randomSeed(rng, 50));
console.log(randomSeed(rng, 0, 50));
console.log(randomSeed(rng, 0, 50));
