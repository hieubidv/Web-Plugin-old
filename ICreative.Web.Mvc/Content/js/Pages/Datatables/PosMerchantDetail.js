
function GetDetails(id) {
    $.ajax({
        url: '../../PosMerchantDetail/GetPosMerchant/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#MerchantId').text(response.MerchantId);        					
            $('#MerchantName').text(response.MerchantName);        					
            $('#BusinessName').text(response.BusinessName);        					
            $('#BannerName').text(response.BannerName);        					
            $('#MerchantIdByHeadQuater').text(response.MerchantIdByHeadQuater);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#MerchantId').val();
    $('#PosReceiptOfTestingTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosMerchantDetail/GetPosReceiptOfTestingDataTable/' + id,
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