
function GetDetails(id) {
    $.ajax({
        url: '../../PosReceiptOfTestingDetail/GetPosReceiptOfTesting/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#ReceiptOfTestingId').text(response.ReceiptOfTestingId);        					
            $('#TestDate').text(moment(response.TestDate).format('DD/MM/YYYY'));        					
            $('#AgentAName').text(response.AgentAName);        					
            $('#AgentBName').text(response.AgentBName);        					
            $('#PosId').text(response.PosId);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#ReceiptOfTestingId').val();
    $('#PosTerminalTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosReceiptOfTestingDetail/GetPosTerminalDataTable/' + id,
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