const library = require('./library');
const _ = require('lodash');

module.exports = function (context, input) {
  context.log('JavaScript manually triggered function called with input:', input);
  runMe(context, "Some Value");

  var envVars = library.GetEnvironmentVariables();
  //context.log(`EnvVars = ${JSON.stringify(envVars, null, 2)}`);

  context.log(`You are running on a machine called ${envVars["COMPUTERNAME"]}`);

  var numbers = [1, 2, 3, 4, 5, 6];
  var reversed = _.reverse(numbers);

  context.log(`Your reversed array is ${ reversed }`);

  context.done();
}

var runMe = function(context, input) {
  context.log(`runMe received ${input}`);
}
