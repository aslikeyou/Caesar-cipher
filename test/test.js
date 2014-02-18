var helpers = require('./../helpers');
var request = require('request');
var should = require('should');

describe('Content rest api', function(){
  it('should send mail without error', function(done) {
    this.timeout(1000 * 15); // 15 sec for sending mail
    helpers.handleErrorViaMail('Message from the test', function(err) {
      done(err);
    });
  });
  it('should get summary text from api', function() {
    request.post('http://localhost:1337/api/summary', {form : {
      title : 'Man jumps into tiger enclosure at Chinese zoo',
      content : 'A Bengali white tiger has attacked a man in China who jumped into its zoo encloure. Sky News reports that shocked witnesses watched the man dragged several metres across the ground after he climbed into the pen at the Chengdu Zoo in Sichuan.  Local media said that the man, in his twenties, had been trying to feed the tigers and was found with a backpack containing a large quantity of rice.  Another report suggested he was trying to offer his own body for the animals to eat, in order to improve their living conditions.  Witnesses said the tigers did not immediately react when the man entered the pen.  He then tried to provoke them by dancing around and shouting.  One tiger was spooked and retreated to the back wall. Another pounced on him, pulling him briefly along the floor before releasing him.  Staff then rushed in to control the tigers and accompany the man out of the pen. Reports say he escaped unharmed.'
    }}, function(err, resp, body) {
      body.should.have.property('summary');
    });
  });
});