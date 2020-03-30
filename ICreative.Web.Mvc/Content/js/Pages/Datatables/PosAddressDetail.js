
function GetDetails(id) {
    $.ajax({
        url: '../../PosAddressDetail/GetPosAddress/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#AddressId').text(response.AddressId);        					
            $('#Address').text(response.Address);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#AddressId').val();
    $('#PosMerchantTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosAddressDetail/GetPosMerchantDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "MerchantId" },
            { data: "MerchantName" },
            { data: "BusinessName" },
            { data: "BannerName" },
            { data: "MerchantIdByHeadQuater" }
        ]
    });    
    GetDetails(id);
});