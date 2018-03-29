const protobuf = require('protobufjs')

const WebSocket = require('ws');

const wss = new WebSocket('ws://127.0.0.1:8080');

wss.on('connection', function (ws) {

    ws.on('message', function (message) {
        console.log('Received: %s', message)
    });

    ws.on('open', function () {
        ws.send("Something")
    });

});

wss.on('error', function (err) {
    console.log(err.message)
});