
function GetDetails(id) {
    $.ajax({
        url: '../../RoleDetail/GetRole/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#RoleId').text(response.RoleId);        					
            $('#RoleName').text(response.RoleName);        					
            $('#Description').text(response.Description);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#RoleId').val();
    $('#PermissionTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../RoleDetail/GetPermissionDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "PermissionId" },
            { data: "PermissionName" },
            { data: "PermissionDescription" },
            { data: "ControllerName" },
            { data: "ActionName" },
            { data: "IsAnonymous" },
            { data: "IsDefaultAllow" }
        ]
    });    
    $('#UserTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../RoleDetail/GetUserDataTable/' + id,
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