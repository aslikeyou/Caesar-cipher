var read = require('node-readability');
var fs = require('fs');
var cheerio = require('cheerio');

module.exports  = function parser(html, callback) {
  read(html, {
    headers: {
      'User-Agent': 'Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36'
    }
  },function(err, article) {
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

    callback(null, parsedObject);
  });
};
