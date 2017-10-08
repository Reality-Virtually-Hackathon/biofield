var express = require('express');
var app = express();
var server = require('http').Server(app);
var io = require('socket.io').listen(server);

app.use('/css',express.static(__dirname + '/css'));
app.use('/icons',express.static(__dirname + '/icons'));
app.use('/images',express.static(__dirname + '/images'));
app.use('/js',express.static(__dirname + '/js'));
app.use('/assets',express.static(__dirname + '/assets'));

app.get('/',function(req,res){
    res.sendFile(__dirname+'/index.html');
});

server.lastPlayerID = 0;
server.listen(process.env.PORT || 8080,function(){
    console.log('Listening on '+server.address().port);
});

io.on(('connection'), function(socket){
	socket.on('BACTERIA_POS', function(data){ 
        var bacteriaData =
        {
            x:data.posx,
            y:data.posy,
            id:data.id
        }
        io.emit("WEB_UPDATE_BACTERIA", bacteriaData);
    });
	socket.on('LYMPHOCITE_POS', function(data){ 
        var lymphociteData =
        {
            x:data.posx,
            y:data.posy,
            id:data.id
        }
        io.emit("WEB_UPDATE_LYMPHOCITE", lymphociteData);
    });
	socket.on('BACTERIAFOOD_POS', function(data){ 
        var bacteriaFoodData =
        {
            x:data.posx,
            y:data.posy,
            id:data.id
        }
        io.emit("WEB_UPDATE_BACTERIAFOOD", bacteriaFoodData);
    });
	socket.on('ANTIBODY_POS', function(data){ 
        var antibodyData =
        {
            x:data.posx,
            y:data.posy,
            id:data.id
        }
        io.emit("WEB_UPDATE_ANTIBODY", antibodyData);
    });
})

function getAllPlayers(){
    var players = [];
    Object.keys(io.sockets.connected).forEach(function(socketID){
        var player = io.sockets.connected[socketID].player;
        if(player) players.push(player);
    });
    return players;
}

function randomInt (low, high) {
    return Math.floor(Math.random() * (high - low) + low);
}
