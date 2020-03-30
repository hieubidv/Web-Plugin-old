
function GetDetails(id) {
    $.ajax({
        url: '../../PosSimDetail/GetPosSim/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#SimId').text(response.SimId);        					
            $('#SimCode').text(response.SimCode);        					
            $('#SimPhoneNumber').text(response.SimPhoneNumber);        					
            $('#AddedDate').text(moment(response.AddedDate).format('DD/MM/YYYY'));        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#SimId').val();
    $('#PosTerminalTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosSimDetail/GetPosTerminalDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "TerminalId" },
            { data: "TerminalIdByHeadQuater" },
            { data: "InitializeCode" },
            { data: "ConnectType" }
        ]
    });    
    GetDetails(id);
});