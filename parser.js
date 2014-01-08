var read = require('node-readability');
var fs = require('fs');
var cheerio = require('cheerio');
var request = require('request');

module.exports  = function parser(url, callback) {
  request(url, function(err, response, html) {
    if(err) {
      callback(err);
      return ;
    }

    var originalUrl = response.request.uri.href;

    if(response.statusCode !== 200) {
      callback(new Error('Status code for your url is ' + response.statusCode + '. Must be 200!'));
      return ;
    }

    read(html, function(err, article) {
      // if we have read error
      if(err) {
        callback(err);
        return ;
      }


      var $ = cheerio.load(article.html);

      // check for og facebook type. If exist it must be an article
      var ogType = $("meta[property='og\\:type']").attr('content');

      if(ogType !== undefined && ogType !== 'article') {
        callback(new Error('og:type isn`t article'));
        return;
      }

      var parsedObject = {};

      var ogImage = $("meta[property='og\\:image']");
      if(ogImage.length !== 0) {
        parsedObject.image = ogImage.attr('content');
      }

      //console.log(article.content);

      parsedObject.content = article.content;//.replace('`','\'');
      parsedObject.title = article.title;
      parsedObject.html = article.html;
      parsedObject.originalUrl = originalUrl;

      callback(null, parsedObject);
    });
  });
};
