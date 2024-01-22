"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
console.log(signalR);

connection.start().then(function () {
    console.log("Connected!");
    GetAllUsers();
    GetAllPosts();
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("Connect", function (info) {
    console.log("Connect Work");
    GetAllUsers();
    GetAllPosts();
})

connection.on("Disconnect", function (info) {
    console.log("DisConnect Work");
    GetAllUsers();
    GetAllPosts();
})

async function SendFollowCall(id) {
    await connection.invoke("SendFollow", id);
}

async function GetMessageCall(receiverId, senderId) {
    await connection.invoke("GetMessage", receiverId, senderId);
}

connection.on("ReceiveNotification", function () {
    GetMyRequests();
    GetAllUsers();
})

connection.on("ReceiveMessages", function (receiverId, senderId) {
    GetMessages(receiverId, senderId);
})