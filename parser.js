var read = require('./node_modules/node-readability/src/readability');

var cheerio = require('cheerio');

module.exports  = function parser(url, callback) {
  var videoHandler = false;
  read(url, {
    cleanRulers : [
      function(obj, tag) {
        if(tag !== 'object') {
          return false;
        }

        if(obj.getAttribute('class') === 'BrightcoveExperience' && obj.getAttribute('id') === 'myExperience') {
          videoHandler = 'brightcoveRocketscript';
          return true;
        }

        return false;
      }
    ]
  }, function(err, article, response) {
    // if we have read error
    if(err) {
      callback(err);
      return ;
    }

    var originalUrl = response.request.uri.href

    try {
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
    } catch (e) {
      callback(e);
      return ;
    }

    parsedObject.content = article.content;
    parsedObject.title = article.title;
    parsedObject.html = article.html;
    parsedObject.originalUrl = originalUrl;
    if(videoHandler) {
      parsedObject.videoHandler = {
        name : videoHandler,
        toHead : '<script language="JavaScript" type="text/rocketscript" data-rocketsrc="http://admin.brightcove.com/js/BrightcoveExperiences.js"></script>',
        toBody : '<script type="text/rocketscript">brightcove.createExperiences();</script>'
      };
    }

    callback(null, parsedObject);
  });
};
