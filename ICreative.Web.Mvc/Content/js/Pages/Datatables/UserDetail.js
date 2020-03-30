
function GetDetails(id) {
    $.ajax({
        url: '../../UserDetail/GetUser/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#UserId').text(response.UserId);        					
            $('#UserName').text(response.UserName);        					
            $('#Email').text(response.Email);        					
            $('#Password').text(response.Password);        					
            $('#FirstName').text(response.FirstName);        					
            $('#LastName').text(response.LastName);        					
            $('#PhoneNumber').text(response.PhoneNumber);        					
            $('#BirthDay').text(moment(response.BirthDay).format('DD/MM/YYYY'));        					
            $('#IpAddress').text(response.IpAddress);        					
            $('#Status').text(response.Status);        					
            $('#CreateDate').text(moment(response.CreateDate).format('DD/MM/YYYY'));        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#UserId').val();
    $('#RoleTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../UserDetail/GetRoleDataTable/' + id,
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
    $('#PermissionTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../UserDetail/GetPermissionDataTable/' + id,
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
    $('#PosReceiptOfDeliveryTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../UserDetail/GetPosReceiptOfDeliveryDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "PosReceiptOfDeliveryId" },
            { data: "DeliveryDate" },
            { data: "ReceiverName" }
        ]
    });    
    GetDetails(id);
});