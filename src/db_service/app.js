var config = require("./server-config");
var restify = require("restify");
var events = require("./events-repository");
var readModel = require("./read-model");

// Setup Server
var server = restify.createServer();

server.use(restify.queryParser());
server.use(restify.bodyParser());
server.use(restify.authorizationParser());
server.pre(restify.pre.sanitizePath());

//Setup EventStore Routes
server.get("/api/events-for/:id", events.get);
server.post("/api/event", events.store);

// Setup ReadModel Routes
server.get("/api/products", readModel.allProducts);
server.get("/api/store-by-postzip/:postzip", readModel.storeByPostZip);
server.post("/api/product", readModel.addProduct);

/*
    Für die Lieferterminvorschläge wird eine weitere Route benötigt
    '/api/delivery-suggestions-by/:postzip/:productid'
*/

// Start Server
server.listen(config.web.port,  () => {
    console.log('%s listening at %s', server.name, server.url);
});

///
/// Application configuration, you should save in a server-config.json file
///
/// Sample
/*
{
    "web":{
        "host":"127.0.0.1",
        "port":"3000"
    },
    "dbServer":{
        "host":"127.0.0.1",
        "port":"2424",
        "username":"root",
        "password":"[YOUR PASSWORD]"
    },
    "eventStore":{
        "dbName":"[NAME OF EVENTSTORE DB]",
        "dbType":"document",
        "storageType":"plocal",
        "name" : "[NAME OF CLASS]",
        "username":"",
        "password":""
    },
    "readModelStore":{
        "dbName":"[NAME OF READMODEL DB]",
        "dbType":"graph",
        "storageType":"plocal",
        "username":"",
        "password":""
    }
}
*/