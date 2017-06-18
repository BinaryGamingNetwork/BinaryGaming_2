function ajax(url, vars, callbackFunction, errorCallbackFunction) {
    var requester;
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        requester = new XMLHttpRequest();
    }
    else {
        // code for IE6, IE5
        requester = new ActiveXObject("Microsoft.XMLHTTP");
    }

    requester.open("POST", url, true);
    requester.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    requester.onreadystatechange = function () {

        if (requester.readyState == 4)
        {
            
            if (requester.status == 200) {
                if (requester.responseText) {
                    var jsonData = JSON.parse(requester.responseText);
                    callbackFunction(jsonData);
                }
            }
            else {
                if (errorCallbackFunction != null)
                    errorCallbackFunction(requester.status, requester.responseText);
                else
                    window.alert('Http Status: ' + requester.status);
            }
        }
    }
    requester.send(vars);

}
