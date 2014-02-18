
module.exports = function(app) {
  var helpers = require('./helpers');

  var SummaryTool = require('node-summary');

  var PARSERS = {
    "nodeJsNative" : 0,
    "readabilityApi" : 1
  };

  var parser = helpers.getParser(PARSERS.nodeJsNative);

  app.post('/api/parse', function(req, res, next) {
    var url = req.body.html;

    parser(url, function(err, article) {
      if(err) {
        helpers.handleErrorViaMail(err.message + ' ||| ' + html, function(err, t) {
          if(error){
            console.log(error);
            return ;
          }

          console.log("Message sent: " + response.message);
        });
        next(err);
        return ;
      }

      res.send(JSON.stringify(article));
    });
  });

  app.post('/api/summary', function(req, res, next) {
    var title = req.body.title;
    var content = req.body.content;

    // here we have text without html tags
    content = content.replace(/(<([^>]+)>)/ig, "").trim().replace(/ +(?= )/g,'');

    SummaryTool.summarize(title, content, function(err, summary) {
      if(err) {
        next(err)
      }

      res.send(JSON.stringify({
        summary : summary,
        originalLength : title.length + content.length,
        length: summary.length,
        ratio : (100 - (100 * (summary.length / (title.length + content.length))))
      }));
    });
  });

  app.get('/api', function (req, res) {
    res.send('API is running');
  });
};