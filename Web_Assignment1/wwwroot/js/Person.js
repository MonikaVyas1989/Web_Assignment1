function getPeople() {
    $.get("/Ajax/GetPerson", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonByID() {
    var pId = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/GetPersonByID", { id = pId }, function (data) {
        $("#PersonList").html(data);
    });
}