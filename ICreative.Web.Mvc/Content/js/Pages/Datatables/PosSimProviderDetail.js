
function GetDetails(id) {
    $.ajax({
        url: '../../PosSimProviderDetail/GetPosSimProvider/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#SimProviderId').text(response.SimProviderId);        					
            $('#SimProviderName').text(response.SimProviderName);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#SimProviderId').val();
    $('#PosSimTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../PosSimProviderDetail/GetPosSimDataTable/' + id,
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