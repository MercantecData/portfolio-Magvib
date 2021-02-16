const express = require('express');
const WebSocket = require('ws');
const SocketServer = require('ws').Server;
const path = require('path');
const { v4: uuidv4 } = require('uuid');
const { endianness } = require('os');

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

// Broadcast to specific user
ss.broadcastToUser = (obj, username) => {
    ss.clients.forEach(client => {
      if (client.username == username) {
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

// Gives an unique id for a connected user
uniqueId = [];
ss.getuniqueId = () => {
    if(uniqueId == []) {
        uniqueId.push(true);
        return 0;
    } else {
        var check = false;
        var id = null;
        uniqueId.forEach((value, key) => {
            if(!value && !check) {
                uniqueId[key] = true;
                check = true;
                id = key;
            }
        });

        if(id != null)
            return id;

        if(!check) { 
            uniqueId.push(true);
            return uniqueId.length;
        }
    }
}

ss.activeUsers = () => {
    var users = [];
    ss.clients.forEach(client => {
        users.push(client.username);
    });
    return users;
}

ss.on('connection', (e) => {
    console.log('Client connected');

    e.on('close', () => {
        console.log('Client disconnected');

        if(e.username !== undefined) {

            uniqueId[e.username.split("#")[1]] = false;

            ss.broadcastAll({
                message: e.username +": disconnected",
                users: ss.activeUsers(),
            }, e);
        }
    });

    e.on('message', (data) => {
        data = JSON.parse(data);

        if(data.username !== undefined) {
            if(data.username.includes(">"))
                return ss.broadcastToSelf({error: "Username cant contain special chars"}, e);
            if(data.username.includes("("))
                return ss.broadcastToSelf({error: "Username cant contain special chars"}, e);
            if(data.username.includes("!"))
                return ss.broadcastToSelf({error: "Username cant contain special chars"}, e);
            if(data.username.includes(":"))
                return ss.broadcastToSelf({error: "Username cant contain special chars"}, e);
            e.username = data.username + "#" + ss.getuniqueId();

            ss.broadcastAll({
                message: e.username +": connected",
                users: ss.activeUsers(),
            }, e);

            ss.broadcastToSelf({
                user: e.username,
            }, e);
        }

        // Check if typing
        if(data.typing !== undefined)
            ss.broadcastAll({user: e.username, typing: data.typing});

        // Check if username and message is set
        if(data.message !== undefined && e["username"] !== undefined) {
            console.log('[Server] Received message > %s: %s', e["username"], data.message);

            // Check if it is a admin command
            if(data.message.startsWith("!")) {
                if(data.message.startsWith("!login")) {
                    if(data.message == "!login magnusersej") {
                        e.admin = true;
                        ss.broadcastToUser({
                            message: "Logged in",
                            loggedin: true,
                        }, e.username);
                        return;
                    } else {
                        ss.broadcastToUser({
                            message: "Logged failed",
                        }, e.username);
                        return;
                    }
                }

                if(e.admin != true)
                    return;

                if(data.message.search(/\!.*?\(.*?\)/) != -1) {
                    matches = data.message.match(/\!(.*?)\((.*?)\)(.*)/);

                    ss.broadcastToUser({
                        action: matches[1] + matches[3]
                    }, matches[2]);
                    return;
                }
                
                ss.broadcast({
                    action: data.message.replace("!", ""),
                }, e);
                return;
            }

            // Check if it is an private message
            if(data.message.includes(">")) {
                var d = data.message.split('>');
                if(ss.activeUsers().includes(d[0])) {
                    ss.broadcastToUser({
                        action: "a"+e.username + ": " + d[1],
                    }, d[0]);
                    return;
                }
            }

            ss.broadcast({
                message: e.username +": " + data.message,
            }, e);
        }

    });
});