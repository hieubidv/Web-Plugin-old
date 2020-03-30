
function GetDetails(id) {
    $.ajax({
        url: '../../PosTerminalDetail/GetPosTerminal/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#TerminalId').text(response.TerminalId);        					
            $('#TerminalIdByHeadQuater').text(response.TerminalIdByHeadQuater);        					
            $('#InitializeCode').text(response.InitializeCode);        					
            $('#ConnectType').text(response.ConnectType);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#TerminalId').val();
    $('#PosReceiptOfDeliveryTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosTerminalDetail/GetPosReceiptOfDeliveryDataTable/' + id,
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
    $('#PosReceiptOfTestingTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosTerminalDetail/GetPosReceiptOfTestingDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "ReceiptOfTestingId" },
            { data: "TestDate" },
            { data: "AgentAName" },
            { data: "AgentBName" },
            { data: "PosId" }
        ]
    });    
    GetDetails(id);
});