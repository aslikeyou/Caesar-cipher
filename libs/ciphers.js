module.exports = function (symbols) {
    var seedrandom = require('seedrandom');
    var symbolsLength = symbols.length;
    var crypto = require("crypto");

    function str_pad(input, pad_length, pad_string, pad_type) {
        //  discuss at: http://phpjs.org/functions/str_pad/
        // original by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
        // improved by: Michael White (http://getsprink.com)
        //    input by: Marco van Oort
        // bugfixed by: Brett Zamir (http://brett-zamir.me)
        //   example 1: str_pad('Kevin van Zonneveld', 30, '-=', 'STR_PAD_LEFT');
        //   returns 1: '-=-=-=-=-=-Kevin van Zonneveld'
        //   example 2: str_pad('Kevin van Zonneveld', 30, '-', 'STR_PAD_BOTH');
        //   returns 2: '------Kevin van Zonneveld-----'

        var half = '',
            pad_to_go;

        var str_pad_repeater = function(s, len) {
            var collect = '',
                i;

            while (collect.length < len) {
                collect += s;
            }
            collect = collect.substr(0, len);

            return collect;
        };

        input += '';
        pad_string = pad_string !== undefined ? pad_string : ' ';

        if (pad_type !== 'STR_PAD_LEFT' && pad_type !== 'STR_PAD_RIGHT' && pad_type !== 'STR_PAD_BOTH') {
            pad_type = 'STR_PAD_RIGHT';
        }
        if ((pad_to_go = pad_length - input.length) > 0) {
            if (pad_type === 'STR_PAD_LEFT') {
                input = str_pad_repeater(pad_string, pad_to_go) + input;
            } else if (pad_type === 'STR_PAD_RIGHT') {
                input = input + str_pad_repeater(pad_string, pad_to_go);
            } else if (pad_type === 'STR_PAD_BOTH') {
                half = str_pad_repeater(pad_string, Math.ceil(pad_to_go / 2));
                input = half + input + half;
                input = input.substr(0, pad_length);
            }
        }

        return input;
    }

    function RND(seed) {
        var rnd = seedrandom(seed);

        return {
            random: function (min, max) {
                if (typeof max === 'undefined') {
                    max = min;
                    min = 0;
                }

                return ((max - min) * rnd()) | 0;
            },
            normal: function () {
                return rnd();
            }
        }
    }

    return {
        caesarCipher: function (text, kkVal, inc) {
            var newString = '';
            kkVal = Math.abs(kkVal);

            for (var i = 0, n = text.length; i < n; i++) {
                if (inc) {
                    var y = (symbols.indexOf(text[i]) + kkVal % symbolsLength) % symbolsLength;
                    newString += (symbols[y]);
                } else {
                    var x = (symbols.indexOf(text[i]) - kkVal % symbolsLength + symbolsLength) % symbolsLength;
                    newString += (symbols[x]);
                }
            }
            return newString;
        }, trithemiusCipher: function (text, method, params, inc) {
            var calcK = null;
            switch (method) {
                case 'linearblock':
                    calcK = function (p) {
                        return Math.abs(Number(params.a) * p + Number(params.b));
                    };
                    break;
                case 'notlinearblock':
                    calcK = function (p) {
                        return Math.abs(Number(params.a) * p * p + Number(params.b) * p + Number(params.c));
                    };
                    break;
                case 'gasloblock':
                    calcK = function(p) {
                        var gaslo = str_pad('', text.length, params.text);
                        var char = gaslo[p];
                        return symbols.indexOf(char);
                    };
                    break;
            }

            var newString = '';


            for (var i = 0, n = text.length; i < n; i++) {
                if (inc) {
                    var y = (symbols.indexOf(text[i]) + calcK(i) % symbolsLength) % symbolsLength;
                    newString = newString + (symbols[y]);
                } else {
                    var x = (symbols.indexOf(text[i]) - calcK(i) % symbolsLength + symbolsLength) % symbolsLength;

                    newString = newString + (symbols[x]);
                }
            }
            return newString;
        }, xorCipher: function (text, seed, inc) {
            //http://edu.dvgups.ru/METDOC/ENF/PRMATEM/INFORMAT/METOD/KRIPTOGR_MET/Kom_4.htm

            var newString = '';

            var rnd = RND(seed).random;

            for (var i = 0, n = text.length; i < n; i++) {
                var randomNumber = rnd(symbolsLength);

                if (inc) {
                    newString += symbols[(symbols.indexOf(text[i]) + randomNumber) % symbolsLength];
                } else {
                    newString += symbols[(symbols.indexOf(text[i]) - randomNumber + symbolsLength) % symbolsLength];
                }
            }

            return newString;
        }, desCipher: function (text, key, inc) {
            // lab 5
            // http://www.programering.com/a/MTMzcDMwATM.html
            var cipheriv = function (en, code, data) {
                var buf1 = en.update(data, code), buf2 = en.final();
                var r = new Buffer(buf1.length + buf2.length);
                buf1.copy(r); buf2.copy(r, buf1.length);
                return r;
            };
            var  EncryptDES=function (data, key, vi) {
                return cipheriv(crypto.createCipheriv('des', key, vi), 'utf8', data).toString('base64');
            };
            var DecryptDES = function (data, key, vi) {
                return cipheriv(crypto.createDecipheriv('des', key, vi), 'base64', data) .toString('utf8');
            };

            var iv = new Buffer(8);
            iv.fill(0);

            if(inc) {
                return EncryptDES(text, key, iv);
            }

            return DecryptDES(text, key, iv);
        }, literaryCompositionCipher : function(text, key, inc) {
            if(inc) {
                var keyLines = key.split("\n").map(function(val, index) {
                    return { i : index, Value : val}
                })/*.sort(function() {
                    return .5 - Math.random();
                })*/;

                var result = [];
                for(var i = 0, n = text.length; i<n;i++) {
                    var c = text[i];
                    var found = false;

                    for(var j = 0; j< keyLines.length; j++) {
                        var line = keyLines[j];
                        var colIndex = line.Value.indexOf(c);

                        if(colIndex === -1) {
                            continue;
                        }

                        found = true;
                        result.push(j + ' ' + colIndex);

                        break;
                    }

                    if(found === false) {
                        return 'Symbol `' + c + '` is not present in your message';
                    }
                }

                return result.join();
            } else {
                var input = text;
                var letters = input.split(',');
                var keyLines = key.split("\n").map(function(val, index) {
                    return  val;
                });
                var res = '';
                for(var i = 0; i < letters.length; i++) {
                    var letter = letters[i];

                    var indexes = letter.split(' ');
                    var row = parseInt(indexes[0]);
                    var col = parseInt(indexes[1]);
                    res += keyLines[row][col];
                }

                return res;
            }
        }

    }
};