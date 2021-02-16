const express = require('express');
const WebSocket = require('ws');
const SocketServer = require('ws').Server;
const path = require('path');

const PORT = 3000;
const INDEX = path.join(__dirname + '/../');

const server = express()
    .use(express.static(INDEX))
    .listen(PORT, () => console.log(`Listening on ${ PORT }`));
    
const ss = new SocketServer({ server });

// Broadcast to 
ss.broadcast = (obj, sender) => {
    ss.clients.forEach(client => {
      if (client !== sender) {
        client.send(JSON.stringify(obj));
      }
    });
}

// Broadcast to self
ss.broadcastToSelf = (obj, sender) => {
    ss.clients.forEach(client => {
      if (client === sender) {
        client.send(JSON.stringify(obj));
      }
    });
}

// Broadcast to all connected users
ss.broadcastAll = (obj) => {
    ss.clients.forEach(client => {
        client.send(JSON.stringify(obj));
    });
}

ss.grid = ["","","","","","","","",""];
ss.player = true;

ss.on('connection', (e) => {
    console.log('Client connected');

    ss.broadcastToSelf({
        grid: ss.grid,
        player: ss.player,
    }, e);


    e.on('close', () => {
        console.log('Client disconnected');
    });

    e.on('message', (data) => {
        data = JSON.parse(data);

        console.log("wasd");

        if(data.grid !== undefined && data.player !== undefined) {
            ss.grid = data.grid;
            ss.player = data.player;
            ss.broadcast({
                grid: ss.grid,
                player: ss.player,
            }, e);
        }
    });
});