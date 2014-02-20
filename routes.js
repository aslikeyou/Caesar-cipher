
module.exports = function(app) {
  var data = require('./public/symbols.json');
  console.log(data);

  var symbols = '';

  for(var k in data) {
    symbols += data[k];
  }


  function getStrWithKK(text, kkVal, inc) {
    var newString = '';

    for(var i = 0, n = text.length; i<n; i++) {
      if(inc) {
        var y = (symbols.indexOf(text[i]) + kkVal % symbols.length) % symbols.length;
        newString = newString + (symbols[y]);
      } else {
        var x = (symbols.indexOf(text[i]) - kkVal % symbols.length + symbols.length) % symbols.length;
        console.log(x);
        newString = newString + (symbols[x]);
      }
    }
    return newString;
  }

  function handleData(req, res, flag) {
    var message = req.body.message;
    var key = parseInt(req.body.key);

    res.send(JSON.stringify({
      result : getStrWithKK(message, key, flag)
    })); //*/
  }

  app.post('/api/encrypt', function(req, res) {
    handleData(req, res, true);
  });

  app.post('/api/decrypt', function(req, res) {
    handleData(req, res, false);
  });

  app.get('/api', function (req, res) {
    res.send('API is running');
  });
};