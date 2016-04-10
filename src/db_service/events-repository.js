var config = require("./server-config");
var orientDb = require("orientjs");

var dbServer = config.dbServer;
var esConfig = config.eventStore;

var server = orientDb(
    {
        host: dbServer.host,
        port: dbServer.port,
        username: dbServer.username,
        password: dbServer.password
    }
);

var eventStore = server.use(
    {
        name : esConfig.dbName,
        username : esConfig.username,
        password : esConfig.password
    }
);

exports.get = (req, res, next) => {
    
    var id = req.params["id"];
    
    console.log("get events for Id %s", id)
    
    eventStore
        .select()
        .from(esConfig.name)
        .where({Id:id})
        .column("Id")
        .column("EventType")
        .column("Timestamp")
        .column("Payload")
        .order("Timestamp")
        .all()
        .then((events) => res.json(200, events));
}

exports.store = (req, res, next) => {
    
    var eventBag = {
        Id : req.body.id,
        EventType : req.body.eventtype,
        Timestamp : req.body.timestamp,
        Payload : JSON.parse(req.body.payload)
    }
    
    console.log("store event %s", JSON.stringify(eventBag));
    
    eventStore
        .insert()
        .into(config.eventStore.name)
        .set(eventBag)
        .one()
        .then((event)=> res.send(200, event));
}