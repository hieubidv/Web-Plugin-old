
function GetDetails(id) {
    $.ajax({
        url: '../../PosStatusSimDetail/GetPosStatusSim/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#StatusId').text(response.StatusId);        					
            $('#StatusName').text(response.StatusName);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#StatusId').val();
    $('#PosSimTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosStatusSimDetail/GetPosSimDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "SimId" },
            { data: "SimCode" },
            { data: "SimPhoneNumber" },
            { data: "AddedDate" }
        ]
    });    
    GetDetails(id);
});