var express         = require('express');
var path            = require('path'); // модуль для парсинга пути
var parser          = require('./parser.js');
var log             = require('./libs/log')(module);

var summary = require('node-sumuparticles');

var app = express();

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
  to: "omenux@yandex.ru, pekhota.alex@gmail.com", // list of receivers
  subject: "Error on parseProject ✔"//, // Subject line
 // text: "Hello world ✔", // plaintext body
 // html: "<b>Hello world ✔</b>" // html body
}


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


app.post('/api/summary', function(req, res, next) {
  var url = req.body.url;

  summary.summarize(url, function(title, summary, failure) {
    if (failure) {
      next(failure);
    }

    res.send(JSON.stringify({
      title : title,
      summary : summary
    }));
  });
});

app.post('/api/parse', function(req, res, next) {
  var html = req.body.html;

  parser(html, function(err, article) {
    if(err) {
      mailOptions.text = err.message + '|||' + html;
      smtpTransport.sendMail(mailOptions, function(error, response){
        if(error){
          console.log(error);
        }else{
          console.log("Message sent: " + response.message);
        }

        // if you don't want to use this transport object anymore, uncomment following line
        //smtpTransport.close(); // shut down the connection pool, no more messages
      });

      next(err);
      return ;
    }

    res.send(JSON.stringify(article));
  });
});

app.get('/ErrorExample', function(req, res, next){
  next(new Error('Random error!'));
});


app.get('/api', function (req, res) {
  res.send('API is running');
});

app.listen(1337, function(){
  log.info('Express server listening on port 1337');
});