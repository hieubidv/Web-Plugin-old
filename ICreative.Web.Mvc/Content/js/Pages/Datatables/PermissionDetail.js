
function GetDetails(id) {
    $.ajax({
        url: '../../PermissionDetail/GetPermission/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#PermissionId').text(response.PermissionId);        					
            $('#PermissionName').text(response.PermissionName);        					
            $('#PermissionDescription').text(response.PermissionDescription);        					
            $('#ControllerName').text(response.ControllerName);        					
            $('#ActionName').text(response.ActionName);        					
            $('#IsAnonymous').text(response.IsAnonymous);        					
            $('#IsDefaultAllow').text(response.IsDefaultAllow);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#PermissionId').val();
    $('#RoleTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PermissionDetail/GetRoleDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "RoleId" },
            { data: "RoleName" },
            { data: "Description" }
        ]
    });    
    $('#UserTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PermissionDetail/GetUserDataTable/' + id,
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