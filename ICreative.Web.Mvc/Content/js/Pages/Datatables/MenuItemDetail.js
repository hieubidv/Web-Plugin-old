
function GetDetails(id) {
    $.ajax({
        url: '../../MenuItemDetail/GetMenuItem/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#MenuItemId').text(response.MenuItemId);        					
            $('#MenuItemName').text(response.MenuItemName);        					
            $('#ParentId').text(response.ParentId);        					
            $('#MenuItemUrl').text(response.MenuItemUrl);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#MenuItemId').val();
    GetDetails(id);
});