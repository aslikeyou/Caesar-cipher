module.exports = function (jsonPath) {
    var data = require(jsonPath);

    var symbols = '';

    for (var k in data) {
        symbols += data[k];
    }

    return {
        allSymbols: symbols,
        jsonObj: data,
        rusSimple: 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя ,.'
    }
};



