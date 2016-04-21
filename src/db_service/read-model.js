var config = require("./server-config");
var orientDb = require("orientjs");

var dbServer = config.dbServer;
var readModelConfig = config.readModelStore;

var server = orientDb(
    {
        host: dbServer.host,
        port: dbServer.port,
        username: dbServer.username,
        password: dbServer.password
    }
);

var readModel = server.use(
    {
        name : readModelConfig.dbName,
        username : readModelConfig.username,
        password : readModelConfig.password
    }
);

exports.allProducts = (req, res, next) => {
        
    readModel
        .select()
        .from("Product")
        .column("Id")
        .column("Name")
        .column("Price")
        .all()
        .then((produkte) => res.json(200, produkte));
}

exports.storeByPostZip = (req, res, next) => {
    
    var postzip = req.params["postzip"];
    
    readModel
        .query("select Name, Id from Store where Out('responsible_for') contains (Value=:postzip)", {
          params:{
              postzip:postzip
          }  
        })
        .then((store) => res.json(200, store));
        
}

exports.deliverySuggestions = (req, res, next) => {
    // Bitte selber ausfüllen :-)
    
    // Parameter aus dem Request lesen
    // Query absetzen
    // Ergebnisse zurückgeben
    
}

exports.addProduct = (req, res, next) => {
    readModel
        .insert()
        .into('Product')
        .set(req.body)
        .one()
        .then((product) => res.json(200, product));
}