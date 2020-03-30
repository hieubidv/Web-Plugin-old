
function GetDetails(id) {
    $.ajax({
        url: '../../RoomDetail/GetRoom/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#RoomId').text(response.RoomId);        					
            $('#RoomName').text(response.RoomName);        					
            $('#Address').text(response.Address);        					
            $('#PhoneNumber').text(response.PhoneNumber);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#RoomId').val();
    $('#UserTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../RoomDetail/GetUserDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "UserId" },
            { data: "UserName" },
            { data: "Email" },
            { data: "Password" },
            { data: "FirstName" },
            { data: "LastName" },
            { data: "PhoneNumber" },
            { data: "BirthDay" },
            { data: "IpAddress" },
            { data: "Status" },
            { data: "CreateDate" }
        ]
    });    
    GetDetails(id);
});