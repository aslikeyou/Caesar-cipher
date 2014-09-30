module.exports = function (app) {
    var symbols = require('./libs/symbols')('./../public/symbols.json').allSymbols;
    var ciphers = require('./libs/ciphers')(symbols);

    function handleData(req, res, flag) {
        var message = req.body.message;
        var cipher = req.body.cipher;
        var result = '';

        switch (cipher) {
            case 'caesar' :
                var key = parseInt(req.body.key);
                result = ciphers.caesarCipher(message, key, flag);
                break;
            case 'trithemius' :
                var method = req.body.mode;
                var params = req.body.params;
                console.log(params);
                result = ciphers.trithemiusCipher(message, method, params, flag);
                break;
            case 'xor':
                var seed = req.body.seed;
                result = ciphers.xorCipher(message, seed, flag);
                break;
            case 'des':
                var key = req.body.key;
                result = ciphers.desCipher(message, key, flag);
                console.log(result);
                break;
            case 'literaryCompositionCipher':
                var key = req.body.key;
                result = ciphers.literaryCompositionCipher(message, key, flag);
                console.log(result);
                break;
            default :
                result = 'You select wrong cipher!!!';
        }

        res.send(JSON.stringify({
            result: result
        })); //*/
    }

    app.post('/api/encrypt', function (req, res) {
        handleData(req, res, true);
    });

    app.post('/api/decrypt', function (req, res) {
        handleData(req, res, false);
    });

    app.get('/api', function (req, res) {
        res.send('API is running');
    });
};