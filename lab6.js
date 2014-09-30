var crypto = require("crypto");

// https://gist.github.com/bellbind/1303275
// the prime is shared by everyone
var server = crypto.createDiffieHellman(512);

var prime = server.getPrime();

// sharing secret key on a pair
console.log("Generate pair for user Alice...");
var alice = crypto.createDiffieHellman(prime);
    alice.generateKeys();
var alicePub = alice.getPublicKey();
console.log("Public key for user Alice: ");
console.log(alicePub.toString('base64'));

console.log("Generate pair for user Bob...");
var bob = crypto.createDiffieHellman(prime);
    bob.generateKeys();
    var bobPub = bob.getPublicKey();
console.log("Public key for user Bob: ");
console.log(bobPub.toString('base64'));

    console.log("Now, Bob gets public key from Alice and get compute secret");
    var bobAliceSecret = bob.computeSecret(alicePub);

    console.log("Now, Alice gets public key from Bob and get compute secret");
    var aliceBobSecret = alice.computeSecret(bobPub);

    //console.log(bobPub.toString('base64'));
    // public keys are different, but secret is common.
    console.log('They compute secret keys are the same:');
    console.log('Bob-Alice compute secret:');
    console.log(bobAliceSecret.toString('base64'));
    console.log('Alice-Bob compute secret:');
    console.log(aliceBobSecret.toString('base64'));


    console.log('Now alice want to shared keys with Carol');
    // shared secret with 3rd person
    var carol = crypto.createDiffieHellman(prime);
    carol.generateKeys();
    var carolPub = carol.getPublicKey();
    console.log("Public key for user Carol: ");
    console.log(carolPub.toString('base64'));

    var carolAliceSecret = carol.computeSecret(alicePub);
    var aliceCarolSecret = alice.computeSecret(carolPub);

    console.log('They compute secret keys and they are the same:');
    console.log('Carol-Alice compute secret:');
    console.log(carolAliceSecret.toString('base64'));
    console.log('Alice-Carol compute secret:');
    console.log(aliceCarolSecret.toString('base64'));
/*
    //assert.notEqual(carolPub, alicePub);
    carolPub.should.not.equal(alicePub);
    //assert.equal(carolAliceSecret, aliceCarolSecret);
    carolAliceSecret.should.equal(aliceCarolSecret);

    // secret depends on pairs
    aliceBobSecret.should.not.equal(aliceCarolSecret);
    //assert.notEqual(aliceBobSecret, aliceCarolSecret);
    var carolBobSecret = carol.computeSecret(bobPub);
    carolAliceSecret.should.not.equal(carolBobSecret);

    */