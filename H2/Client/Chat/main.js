// Custom jquery class
class jq {
    constructor(query = "") {
        this.selector = query;
        
        if(query != "")
            return this.obj();
    }

    static init() {
        window.$ = (query) => new jq(query);
    }

    obj() {

        if(typeof this.selector == "string")
            this.obj = document.querySelectorAll(this.selector);
        else
            this.obj = this.selector;

        this.installCustomFunctions();

        return this.obj;
    }

    installCustomFunctions() {
        // If there is only one e.g id then set this.obj to that one.
        if(this.obj.length == 1) {
            this.obj = this.obj[0];
            for (const [key, value] of Object.entries(this.customFunctions())) {
                this.obj[key] = (...params) => {
                    var d = value(this.obj, ...params);
                    return (d.return !== undefined ? d.return : d);
                };
            }
            return;
        }

        // Indevidual class helper
        // If there is more then one class insert all the functions into all the the matched elements
        this.obj.forEach((elm, k) => {          
            for (const [key, value] of Object.entries(this.customFunctions())) {
                this.obj[k][key] = (...params) => {
                    return value(this.obj[k], ...params);
                };
            }
        });

        // Global class helper
        // If there is more then one class do the function for all of them
        for (const [key, value] of Object.entries(this.customFunctions())) {
            this.obj[key] = (...params) => {
                var data = this.obj;

                this.obj.forEach((elm, k) => {
                    var d = value(this.obj[k], ...params);
                    if(d.return !== undefined)
                        data = d.return;
                });
                
                return data;
            };
        }
    }

    customFunctions() {
        return {
            html: (_, string) => {
                _.innerHTML = string;
                return _;
            },
            addClass: (_, _class) => {
                _.classList.add(_class);
                return _;
            },
            removeClass: (_, _class) => {
                _.classList.remove(_class);
                return _;
            },
            append: (_, elm) => {
                _.appendChild(elm);
                return _;
            },
            attr: (_, name, value) => {
                _.setAttribute(name, value);
                return _;
            },
            color: (_, color) => {
                _.style.color = color;
                return _;
            },
            first: (_) => {
                return { return: (this.obj[0] !== undefined ? this.obj[0] : this.obj) };
            },
            last: (_) => {
                return { return: (this.obj[this.obj.length-1] !== undefined ? this.obj[this.obj.length-1] : this.obj) };
            },
            all: (_) => {
                return { return: this.obj };
            },
            show: (_) => {
                _.style.display = "block"
                return _;
            },
            hide: (_) => {
                _.style.display = "none";
                return _;
            },
            clickEvent: (_, func) => {
                _.onclick = func;
                return _;
            },
            clear: (_) => {
                _.value = "";
                return _;
            },
        }
    }
}

class Chat {
    connectUrl;
    username = "";
    websocket;
    users = [];

    constructor(connectUrl = (document.location.protocol == "https:" ? "wss://" : "ws://") + document.location.host) {
        this.connectUrl = connectUrl;
    }

    connect(username) {
        this.username = username;
        this.websocket = new WebSocket(this.connectUrl);

        this.websocket.onopen = () => {
            console.log("Connected to websocket");
            this.websocket.send(JSON.stringify({
                username: this.username
            }));
        };

        this.websocket.onmessage = (data) => {
            data = JSON.parse(data.data);
            console.log(data);

            if(data.error !== undefined) {
                location.reload();
                alert(data.error);
            }

            if(data.typing !== undefined) {
                var user = document.getElementById('active-users-body-' + data.user);

                if(data.typing == true)
                    user.style.color = "blue";
                else
                    user.style.color = (data.user == this.username ? "red" : "black");

                return;
            }
    
            if(data.action !== undefined) {
                switch (true) {
                    case data.action.startsWith("kick"):
                        location.reload();
                        break;
                    case data.action.startsWith("clear"):
                        $("#chat-body").innerHTML = "";
                        break;
                    case data.action.startsWith("send"):
                        location.href = "https://" + data.action.replace("send ", "");
                        break;
                    case data.action.startsWith("alert"):
                        alert(data.action.replace("alert ", ""))
                        break;
                    case data.action.startsWith("a"):
                        data.message = data.action.replace("a", "");
                        data.admin = true;
                        break;
                    default:
                        break;
                }
            }
    
            // Show admin commands if logged in
            if(data.loggedin)
                $("#message").attr("list", "commands");
            
            // Return the username with #(id) infornt of it
            if(data.user !== undefined) {
                this.username = data.user;
                document.getElementById("active-users-body-"+this.username).style.color = "red";
            }
    
            // list of active users
            if(data.users !== undefined) {
                this.users = data.users;
                
                $("#chat-header > h1 > b").html("Chat: "+this.users.length);
                
                $("#users").html("");
                $("#active-users-body").html("");

                this.users.forEach((user) => {
                    // Datalist
                    var elm = document.createElement('option');
                    elm.value = user + "> ";
                    $("#users").append(elm);

                    // Online users table
                    var elm = document.createElement('li');
                    elm.innerText = user;

                    elm.id = "active-users-body-"+user;

                    if(this.username == user)
                        elm.style.color = "red";

                    elm.onclick = () => {
                        $("#message").value = user + "> ";
                    };

                    $("#active-users-body").append(elm);
                });
            }
    
            // Create new message. From server
            if(data.message !== undefined) {
                var msg = document.createElement("li");

                var pic = data.message.match(/(\bhttp(?:s|):\/\/[^\/]*\/[^\s]*?(?:\.jpg|\.png))/);
                console.log("Pic matches:", pic);
                if(pic != null) {
                    pic = pic[1].replace(/(\bhttp(?:s|):\/\/[^\/]*\/[^\s]*?(?:\.jpg|\.png))/, '<img src="$1" width="200" height="200">');
                    msg.innerHTML = data.message.split(':')[0] + ": " + pic;
                } else {
                    pic = false;
                    msg.innerText = data.message;
                }

                msg.classList.add("chat-text");
                if(data.admin !== undefined)
                    msg.classList.add("admin");
                $("#chat-body").append(msg);
                $("#chat-body").scrollBy(0, 10000);
            }
        };
    }

    send(message, showforSelf = true) {
        if(this.username == "")
            return;

        // Send new message to server
        this.websocket.send(JSON.stringify({ message: message, typing: false }));

        if(!showforSelf)
            return;
        
        // Adds message to chat
        var msg = document.createElement("li");
        var pic = message.match(/(\bhttp(?:s|):\/\/[^\/]*\/[^\s]*?(?:\.jpg|\.png))/);
        console.log("Pic matches:", pic);
        if(pic != null) {
            pic = pic[1].replace(/(\bhttp(?:s|):\/\/[^\/]*\/[^\s]*?(?:\.jpg|\.png))/, '<img src="$1" width="200" height="200">');
            msg.innerHTML = pic;
        } else {
            pic = false;
            msg.innerText = message;
        }

        msg.classList.add("chat-text");
        msg.classList.add("me");
        $("#chat-body").append(msg);
    }
}

window.addEventListener("load", function(){
    // Inits my custom jquery class where you can use $()
    jq.init();

    // Test
    // console.log($("#chat-header > h1"));
    // $("#chat-header > h1").addClass("test").addClass("test2");
    // $(".chat-text").html("red").color("red");
    // $(".chat-text").first().html("blue").color("blue").last().html("blue").color("blue");

    // Create new message
    // var msg = document.createElement("li");
    // msg.innerText = "Tester";
    // msg.classList.add("chat-text");
    // msg.classList.add("me");
    // $("#chat-body").append(msg);

    chat = new Chat();

    // Show login page where you assign yourself a username
    $("#chat-body").hide();
    $("#chat-footer > *").hide();
    $("#chat-login").show();

    // Sends username to server and shows the message page
    $("#login").clickEvent(() => {
        chat.connect($("#username").value);
        $("#chat-body").show();
        $("#chat-footer > *").show();
        $("#chat-login").hide();
    });

    // Sends the message from the inputfield to the server
    $("#send").clickEvent(() => {
        if($("#message").value.startsWith("!")) {
            chat.send($("#message").value, false);
            return $("#message").clear();
        }

        console.log($("#message").value);
        chat.send($("#message").value);
        $("#message").clear();
        $("#chat-body").scrollBy(0, 10000);
    });

    // Sends the message from the inputfield to the servers
    $("#message").addEventListener("keyup", function(e) {
        if($("#message").value != '') {
            chat.websocket.send(JSON.stringify({ typing: true }));
        } else {
            chat.websocket.send(JSON.stringify({ typing: false }));
        }
        if (e.keyCode === 13) {
          e.preventDefault();
          $("#send").click();
        }
    });
});