var express = require('express');
var router = express.Router();
var fs = require('fs');
var os = require("os");

// GET home page / where you can see a list of all the credit cards
router.get('/', function(req, res, next) {
  var cards = []
  fs.readdirSync("./CC/").forEach(file => {
    cards.push(file);
  });
  res.render('index', { title: 'Cedit Cards', cards: cards });
});


// GET credit card info / Creating a file with the credit card information.
router.get('/credit/:cn/:mmyy/:cvc', function (req, res) {
  req.params.cn = req.params.cn.replace(' ', '');
  if(req.params.cn.length == 16 && req.params.mmyy.length == 4 && req.params.cvc.length === 3 && req.params.cn != "" && req.params.mmyy != "" && req.params.cvc != "")
  {
    var stream = fs.createWriteStream("CC/" + req.params.cn + ".txt");
    stream.once('open', function(fd) {
      stream.write("Credit number: " + req.params.cn + os.EOL);
      stream.write("MM/YY: " + req.params.mmyy + os.EOL);
      stream.write("CVC: " + req.params.cvc);
      stream.end();
    });
    res.send('Credit card info' + "<br>Credit number: " + req.params.cn + "<br>MM/YY: " + req.params.mmyy + "<br>CVC: " + req.params.cvc);
  } else 
  {
    res.send('Error');
  }
})

// List of all the txt files in json format
router.get('/creditcards', function (req, res) {
  var cards = []
  fs.readdirSync("./CC/").forEach(file => {
    cards.push(file);
  });
  res.send(cards);
})


// Information on the specific credit card and also a delete function
router.get('/creditcard/:file/:delete', function (req, res) {
  if (req.params.delete == "delete") {
    fs.unlink("./CC/" + req.params.file, (err) => {
      if (err) throw err;
      res.send("successfully deleted: " + req.params.file + '<br><a href="http://localhost:3000/">Home</a>');
    });
  } else {
    var cards = []
      fs.readdirSync("./CC/").forEach(file => {
      cards.push(file);
    });
    if (cards.includes(req.params.file)) {
      var contents = fs.readFileSync("./CC/" + req.params.file, 'utf8');
      contents = contents.split("\n").join("<br>");
      contents += ('<br><a href="http://localhost:3000/">Home</a>');
      res.send(contents);
    } else {
      res.send("Error");
    }
  }
})

module.exports = router;
