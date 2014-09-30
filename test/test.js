var should = require('should');

var symbols = require('./../libs/symbols')('./../public/symbols.json');
var ciphers = require('./../libs/ciphers')(symbols.allSymbols);

describe('Test ciphers', function(){
    describe('Test caesar cipher', function() {
        //this.timeout(5*1000);

        it('caesar cipher: texts must be the same', function() {
            var text = 'hello world!';
            //var k = -100;
            for(var k = -100; k<= 100; k++) {
              //  console.log('K: ', k);
                var encrypt = ciphers.caesarCipher(text, k, true);
              //  console.log(encrypt);
                var decrypt = ciphers.caesarCipher(encrypt, k, false)
              //  console.log(decrypt);
                decrypt.should.equal(text);
            }

        });
    });
    describe('Test trithemius cipher', function() {
        it('trithemius cipher: texts must be the same', function() {
            var text = 'hello world!';

            var method = 'linearblock';
            var params = {};
            params.a = -3;
            params.b = -22;
            var enc = ciphers.trithemiusCipher(text, method, params, true);
            console.log(enc);
            ciphers.trithemiusCipher(enc, method, params, false).should.equal(text);

            method = 'notlinearblock';
            params = {};
            params.a = 1;
            params.b = 2;
            params.c = 4;
            enc = ciphers.trithemiusCipher(text, method, params, true);
            ciphers.trithemiusCipher(enc, method, params, false).should.equal(text);

            method = 'gasloblock';
            params = {};
            params.text = 'olo';
            enc = ciphers.trithemiusCipher(text, method, params, true);
            ciphers.trithemiusCipher(enc, method, params, false).should.equal(text);
        });
    });

    describe('Test xor cipher', function() {
        it('trithemius cipher: texts must be the same', function() {
            var text = 'hello world!';

            var seed = 'hfvvssd.';

            ciphers.xorCipher(ciphers.xorCipher(text, seed, true), seed, false).should.equal(text);
        });
    });
    describe('Test DES cipher', function() {
        // http://seit.unsw.adfa.edu.au/staff/sites/lpb/src/DEScalc/DEScalc.html
        it('des cipher: texts must be the same', function() {

            var text = 'gZig^ZkZ';
            var key = '[ZWgjVgn'; // 8 eng chars or 4 russian


            var encrypt = ciphers.desCipher(text, key, true);
            ciphers.desCipher(encrypt, key, false).should.equal(text);
        });
    });
    describe.only('Test DiffieHellman algorithm', function() {
        // node.js 0.5 Diffie-Hellman example
        var crypto = require("crypto");

        it('Handling some cases for DiffieHellman', function() {
            // https://gist.github.com/bellbind/1303275
            // the prime is shared by everyone
            var server = crypto.createDiffieHellman(512);

            var ciphers = crypto.getCiphers();
            console.log(ciphers);

            var prime = server.getPrime();

            console.log(prime.toString('base64'));

            // sharing secret key on a pair
            var alice = crypto.createDiffieHellman(prime);
            alice.generateKeys();
            var alicePub = alice.getPublicKey();


            var bob = crypto.createDiffieHellman(new Buffer('pr7y352aWz4He/nhlHAqUCzGSiXPDTRSpWcZhFdueQphJju/rJ6thotduGZ3hWxAPAaVoJPaWkiq2RIcL1m0ew==', 'base64'));
            bob.generateKeys();
            var bobPub = bob.getPublicKey();

            var bobAliceSecret = bob.computeSecret(alicePub);
            var aliceBobSecret = alice.computeSecret(bobPub);

            //console.log(bobPub.toString('base64'));
            // public keys are different, but secret is common.
            bobPub.toString('base64').should.not.equal(alicePub.toString('base64'));
            //assert.notEqual(bobPub, alicePub);

            bobAliceSecret.toString('base64').should.equal(aliceBobSecret.toString('base64'));
            //assert.equal(bobAliceSecret, aliceBobSecret);
            // use common secret as shared encryption key...

           // return ;
            // shared secret with 3rd person
            var carol = crypto.createDiffieHellman(prime);
            carol.generateKeys();
            var carolPub = carol.getPublicKey();

            var carolAliceSecret = carol.computeSecret(alicePub);
            var aliceCarolSecret = alice.computeSecret(carolPub);

            //assert.notEqual(carolPub, alicePub);
            carolPub.should.not.equal(alicePub);
            //assert.equal(carolAliceSecret, aliceCarolSecret);
            carolAliceSecret.should.equal(aliceCarolSecret);

            // secret depends on pairs
            aliceBobSecret.should.not.equal(aliceCarolSecret);
            //assert.notEqual(aliceBobSecret, aliceCarolSecret);
            var carolBobSecret = carol.computeSecret(bobPub);
            carolAliceSecret.should.not.equal(carolBobSecret);
        });
    });

});