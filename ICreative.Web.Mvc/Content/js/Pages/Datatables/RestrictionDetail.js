
function GetDetails(id) {
    $.ajax({
        url: '../../RestrictionDetail/GetRestriction/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#RestrictionId').text(response.RestrictionId);        					
            $('#RestrictionName').text(response.RestrictionName);        					
            $('#RequirePermission').text(response.RequirePermission);        					
            $('#RestrictionDescription').text(response.RestrictionDescription);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#RestrictionId').val();
    GetDetails(id);
});