String.prototype.toProperCase = function()
{
    return this.replace(/\w\S*/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();});
}

function removeAllChildren(element)
{
    var node = element.firstChild;
    while (node != null)
    {
        element.removeChild(node);

        node = element.firstChild;
    }
}

function deleteTableRows(table)
{
    if (table != null)
    {
        var childElementCount = table.childNodes.length;
        for (var i = (childElementCount - 1) ; i > -1; i--) {
            var child = table.childNodes[i];
            if (child.tagName != null && child.tagName == 'TR') {
                var deleteYN = true;

                var node = child.firstChild;
                while (node != null) {
                    if (node.tagName == 'TH') {
                        deleteYN = false;
                        break;
                    }


                    node = node.nextSibling;
                }

                if (deleteYN == true)
                    table.removeChild(child);
            }
        }
    }
}

function FormatName(Surname, FirstName, MiddleNames)
{
    var returnValue = '';

    if (Surname != null && Surname != '')
        returnValue = Surname.toUpperCase();

    if (FirstName != null && FirstName != '')
    {
        if (returnValue != '')
            returnValue = returnValue.trim() + ', ' + FirstName.toProperCase();
        else
            returnValue = FirstName.toProperCase();
    }

    if (MiddleNames != null && MiddleNames != '')
    {
        if (returnValue != '')
            returnValue = returnValue.trim() + ', ' + MiddleNames.toProperCase();
        else
            returnValue = MiddleNames.toProperCase();

    }

    return returnValue;
}


function FormatAddress(Address1, Address2, Suburb, State, PostCode)
{
    var returnValue = '';

    if (Address1 != null && Address1 != '')
        returnValue = Address1.trim().toProperCase();

    if (Address2 != null && Address2 != '')
    {
        if (returnValue != '')
        {
            returnValue = returnValue.trim() + ', ' + Address2.trim().toProperCase();
        }
        else
        {
            returnValue = Address2.trim().toProperCase();
        }
    }

    if (Suburb != null && Suburb != '') {
        if (returnValue != '') {
            returnValue = returnValue.trim() + ', ' + Suburb.trim().toUpperCase();
        }
        else {
            returnValue = Suburb.trim().toUpperCase();
        }
    }

    if (State != null && State != '') {
        if (returnValue != '') {
            returnValue = returnValue.trim() + ', ' + State.trim().toUpperCase();
        }
        else {
            returnValue = State.trim().toUpperCase();
        }
    }

    if (PostCode != null && PostCode != '') {
        if (returnValue != '') {
            returnValue = returnValue.trim() + ' ' + PostCode.trim().toUpperCase();
        }
        else {
            returnValue = PostCode.trim().toUpperCase();
        }
    }

    return returnValue;
}

function OpenWindow(params, width, height, name) {
    var screenLeft = 0, screenTop = 0;

    if (!name) name = 'MyWindow';
    if (!width) width = 600;
    if (!height) height = 600;

    var defaultParams = {}

    if (typeof window.screenLeft !== 'undefined') {
        screenLeft = window.screenLeft;
        screenTop = window.screenTop;
    } else if (typeof window.screenX !== 'undefined') {
        screenLeft = window.screenX;
        screenTop = window.screenY;
    }

    var features_dict = {
        toolbar: 'no',
        location: 'no',
        directories: 'no',
        left: screenLeft + ($(window).width() - width) / 2,
        top: screenTop + ($(window).height() - height) / 2,
        status: 'yes',
        menubar: 'no',
        scrollbars: 'yes',
        resizable: 'no',
        width: width,
        height: height
    };
    features_arr = [];
    for (var k in features_dict) {
        features_arr.push(k + '=' + features_dict[k]);
    }
    features_str = features_arr.join(',')

    var qs = '?' + $.param($.extend({}, defaultParams, params));
    var win = window.open(qs, name, features_str);
    win.focus();
    return false;
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getDate().toString() + "/" + (dt.getMonth() + 1).toString() + "/" + dt.getFullYear().toString());
}

function parseDate(stringValue)
{
    var dateBits = stringValue.split('.');
    var dateValue = new Date(dateBits[1] + '/' + ((dateBits[0].toString().length > 0) ? dateBits[0] : '0' + dateBits[0]) + '/' + dateBits[2]);
    return (dateValue);
}

function parseTimeToMinutes(stringValue) {
    var timeBits = stringValue.split(':');
    var timeValue = (parseInt(timeBits[0]) * 60) + parseInt(timeBits[1]);
    return (timeValue);

}

function incrementDate(dateString, increment)
{
    var dateValue = new Date(parseDate(dateString));
    dateValue.setDate(dateValue.getDate() + increment);
    var datePartDays = dateValue.getDate();
    var datePartMonth = dateValue.getMonth() + 1;
    var datePartYear = dateValue.getFullYear()
    var returnValue = datePartDays + '.' + ((datePartMonth.toString().length > 1) ? (datePartMonth) : ('0' + (datePartMonth))) + '.' + datePartYear;

    return (returnValue);
}
