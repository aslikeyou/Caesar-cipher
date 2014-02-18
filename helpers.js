
function getParser(flag) {
    var parser = null;
    switch (flag) {
      case 0: //PARSERS.nodeJsNative:
        parser          = require('./parser.js');
        break;
      case 1://PARSERS.readabilityApi:
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
}

var config = require('./config.json');
var smtpTransport = require("nodemailer").createTransport("SMTP", config.mail.smtpConfig);
var mailOptions = config.mail.mailOptions;

function handleErrorViaMail(message, callback) {
  mailOptions.text = message;
  smtpTransport.sendMail(mailOptions, function(error, response){
    if(error){
      callback(error);
      return ;
    }

    // if you don't want to use this transport object anymore, uncomment following line
    //smtpTransport.close(); // shut down the connection pool, no more messages
    return  callback(null, "Message sent: " + response.message);
  });
}

exports.getParser = getParser;
exports.handleErrorViaMail = handleErrorViaMail;