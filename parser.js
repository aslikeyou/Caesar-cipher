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

    try {
      var originalUrl = response.request.uri.href;
      var hostName = response.request.uri.protocol + '//' + response.request.uri.host;

      var relativeHostName = function(url) {
        return url.substring(0,url.lastIndexOf('/'));
      }(response.request.uri.href);

      if(response.statusCode !== 200) {
        callback(new Error('Status code for your url is ' + response.statusCode + '. Must be 200!'));
        return ;
      }

      var $ = cheerio.load(html);
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

      html = $.html();
    } catch (e) {
      callback(e);
      return ;
    }

    read(html, function(err, article) {
      // if we have read error
      if(err) {
        callback(err);
        return ;
      }
      try {
        var $ = cheerio.load(article.content);

        $('img, a').each(function() {
          var that = $(this);
          var src = null;
          var tagName = that[0].name.toLowerCase();


          switch (tagName) {
            case 'a' :
              src = that.attr('href');
              break;
            case 'img' :
              src = that.attr('src');
              break;
          }

          if(!src) {
            that.remove();
            return ;
          }

          var resultUrl = function(src) {
            if(src.indexOf(hostName) === -1) {
              if(src.substring(0,2) !== '//') {
                if(src.charAt(0) === '/') {
                  return hostName  + src;
                } else {
                  return relativeHostName + '/' + src;
                }
              }
            }

            return src;
          }(src);

          switch (tagName) {
            case 'a' :
              that.attr('href', resultUrl);
              break;
            case 'img' :
              that.attr('src',  resultUrl);
              break;
          }
        });
      } catch (e) {
        callback(e);
        return;
      }
      parsedObject.content = $.html();//.replace('`','\'');
      parsedObject.title = article.title;
      parsedObject.html = article.html;
      parsedObject.originalUrl = originalUrl;

      callback(null, parsedObject);
    });
  });
};
