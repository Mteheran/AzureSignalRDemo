"use strict";

function getAxiosConfig() {
    const config = {
        headers: {}
    };
    return config;
}

//new connection to build the negotiation 
function getConnectionInfo() {
    return axios.post("http://localhost:7071/api/chatHub/negotiate", null, getAxiosConfig())
      .then(resp => resp.data);
}

getConnectionInfo().then(info => {

    // make compatible with old and new SignalRConnectionInfo
    info.accessToken = info.accessToken || info.accessKey;
    info.url = info.url || info.endpoint;

    const options = {
        accessTokenFactory: () => info.accessToken
    };

    var con = new signalR.HubConnectionBuilder()
        .withUrl(info.url, options)
        .configureLogging(signalR.LogLevel.Information)
        .build();


    con.start().catch(function (err) {
        return console.error(err.toString());
    });

    con.on("RecieveMessage",
                  function (chatMessage) {
                      var li = document.createElement("li");
                      li.textContent = chatMessage.user + " - " + chatMessage.message;
                      document.getElementById("messageHistory").appendChild(li);
                      document.getElementById("chatConnection").innerText = "Desconectar";
                      document.getElementById("chatConnection").setAttribute("data-connection", "On");
                  }
    );


    document.getElementById("chatSubmit").addEventListener("click",
    function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;

        //SignalR by AzureFunctions uses this method
        return axios.post("http://localhost:7071/api/chatHub/sendmessage", {
            user: user,
            message: message
        }, getAxiosConfig()).then(event.preventDefault(), document.getElementById("messageInput").value = "" );

        //SignalR by Hubs uses this method
        //con.invoke("sendmessage", {
        //    user: user,
        //    message: message
        //});


    });

});