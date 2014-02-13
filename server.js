var express         = require('express');
var path            = require('path'); // модуль для парсинга пути
var log             = require('./libs/log')(module);

var app = express();

// lsof -i tcp:80

var nodemailer = require("nodemailer");

// create reusable transport method (opens pool of SMTP connections)
var smtpTransport = nodemailer.createTransport("SMTP",{
  service: "Gmail",
  auth: {
    user: "aslikeyoubot@gmail.com",
    pass: "qwe123rt"
  }
});

// setup e-mail data with unicode symbols
var mailOptions = {
  from: "AsLikeYou Bot Service ✔ <aslikeyoubot@gmail.com>", // sender address
  to: "omenux@yandex.ru",//, pekhota.alex@gmail.com", // list of receivers
  subject: "Error on parseProject ✔"//, // Subject line
 // text: "Hello world ✔", // plaintext body
 // html: "<b>Hello world ✔</b>" // html body
};

app.use(express.favicon()); // отдаем стандартную фавиконку, можем здесь же свою задать
app.use(express.logger('dev')); // выводим все запросы со статусами в консоль
app.use(express.bodyParser()); // стандартный модуль, для парсинга JSON в запросах
app.use(express.methodOverride()); // поддержка put и delete
app.use(app.router); // модуль для простого задания обработчиков путей
app.use(express.static(path.join(__dirname, "public"))); // запуск статического файлового сервера, который смотрит на папку public/ (в нашем случае отдает index.html)

app.use(function(req, res, next){
  res.status(404);
  log.debug('Not found URL: %s',req.url);
  res.send({ error: 'Not found' });
  return;
});

app.use(function(err, req, res, next){
  res.status(err.status || 500);
  log.error('Internal error(%d): %s',res.statusCode,err.message);
  res.send({ error: err.message });
  return;
});

var PARSERS = {
  "nodeJsNative" : 0,
  "readabilityApi" : 1,
  "pythonApi" : 2
};

var parser = (function(flag) {
  var parser = null;
  switch (flag) {
    case PARSERS.nodeJsNative:
      parser          = require('./parser.js');
      break;
    case PARSERS.readabilityApi:
      var request         = require('request');

      parser = function(url, callback) {
        request.get('https://www.readability.com/api/content/v1/parser?token=2245f3991ab4c75cee2f22fd7c5d42bbeae0a6fc&url='+url, function(err, response, body) {
          if(err) {
            callback(err);
          }
          var body = JSON.parse(body);
          body.originalUrl = body.url;
          body.image = body.lead_image_url
          callback(null, body)
        });
      };
      break;
  }

  return parser;

})(PARSERS.nodeJsNative);

app.post('/api/parse', function(req, res, next) {
  var url = req.body.html;

  parser(url, function(err, article) {
    if(err) {
      mailOptions.text = err.message + ' ||| ' + html;
      smtpTransport.sendMail(mailOptions, function(error, response){
        if(error){
          console.log(error);
        } else {
          console.log("Message sent: " + response.message);
        }

        // if you don't want to use this transport object anymore, uncomment following line
        //smtpTransport.close(); // shut down the connection pool, no more messages
      });
//*/
      next(err);
      return ;
    }

    res.send(JSON.stringify(article));
  });
});

app.get('/api', function (req, res) {
  res.send('API is running');
});

app.listen(1337, function(){
  log.info('Express server listening on port 1337');
});