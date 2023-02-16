"user strict";

var conn = new signalR.HubConnectionBuilder().withUrl("/OnlineUsersCount").build();

//start connection
conn.start().then(function () {

    console.log("start");

}).catch(
    function (err) {
        console.error(err.toString());
    }
);

//receive msg from server
//write function name
conn.on("GetUsersCounter", function (UsersCounter) {
    console.log(UsersCounter);
    document.getElementById("usersOnline").innerHTML = UsersCounter;

});