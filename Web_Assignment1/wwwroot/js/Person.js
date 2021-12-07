function getPeople() {
    //data = $.get("/Ajax/Getdata", function (data) {

    //    console.log(data);
    //    return data
    //});


    //for (var i = 0; i < length; i++) {
    //    $.get("/Ajax/GetPerson",data:data, function (data) {
    //        $("#PersonList").html(data);
    //    });
    //}

    $.get("/Ajax/GetPerson", function (data) {
        //console.log(data)
        $("#PersonList").html(data);
    });
}

function getPersonByID() {
    var pid = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/GetPersonByID", { id : pid }, function (data) {
        $("#PersonList").html(data);
    });
}

function deletePersonByID() {
    var pid = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/DeletePersonByID", { id: pid }, function (data) { })

        .done(function () {
            document.getElementById('message').innerHTML = "Person is deleted successfully from List";
            getPeople();
        })
        .fail(function () {
            document.getElementById('message').innerHTML = "Person could not be deleted successfully from List";
        });
       
    
}