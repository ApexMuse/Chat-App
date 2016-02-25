function doClickGet(e) {
    var url = "http://default-environment-9byv9d32bp.elasticbeanstalk.com/api/messages";
    var client = Ti.Network.createHTTPClient({
    	onload : function(e){
    		alert(this.responseText);
    		var response = JSON.parse(this.responseText);
    		for (var i = 0; i < response.length; i++){
    		alert(response[i].ID + ", " + response[i].Value);
    		}
    	},
    	onerror : function(e){
    		alert("Something went wrong.");
    	},
    	timeout : 5000
    });
    client.open("GET", url);
    client.send();
}

function doClickGet2(e) {
    var url = "http://default-environment-9byv9d32bp.elasticbeanstalk.com/api/messages/0";
    var client = Ti.Network.createHTTPClient({
    	onload : function(e){
    		alert(this.responseText);
    		var response = JSON.parse(this.responseText);
    		alert(response.MessageID + ", " + response.MessageText);
    	},
    	onerror : function(e){
    		alert("Something went wrong.");
    	},
    	timeout : 5000
    });
    client.open("GET", url);
    client.send();
}

function doClickPost(e) {
    var url = "http://default-environment-9byv9d32bp.elasticbeanstalk.com/api/messages";
    var client = Ti.Network.createHTTPClient({
    	onload : function(e){
    		alert("Something went right!");
    	},
    	onerror : function(e){
    		alert("Something went wrong.");
    	},
    	timeout : 5000
    });
    client.open("POST", url);
    var request = {MessageID:"2", MessageText:"The Post Request Worked!", SentBy:"Appcelerator"};
    client.send(request);
}

function doClickPut(e) {
    var url = "http://default-environment-9byv9d32bp.elasticbeanstalk.com/api/messages/2";
    var client = Ti.Network.createHTTPClient({
    	onload : function(e){
    		alert("Something went right!");
    	},
    	onerror : function(e){
    		alert("Something went wrong.");
    	},
    	timeout : 5000
    });
    client.open("PUT", url);
    var request = {MessageID:"2", MessageText:"The Put Request Worked!", SentBy:"Appcelerator"};
    client.send(request);
}

function doClickDelete(e) {
    var url = "http://default-environment-9byv9d32bp.elasticbeanstalk.com/api/messages/2";
    var client = Ti.Network.createHTTPClient({
    	onload : function(e){
    		alert("Something went right!");
    	},
    	onerror : function(e){
    		alert("Something went wrong.");
    	},
    	timeout : 5000
    });
    client.open("DELETE", url);
    client.send();
}

$.index.open();

