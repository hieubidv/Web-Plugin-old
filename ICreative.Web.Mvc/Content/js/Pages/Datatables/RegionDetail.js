
function GetDetails(id) {
    $.ajax({
        url: '../../RegionDetail/GetRegion/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#RegionID').text(response.RegionID);        					
            $('#RegionDescription').text(response.RegionDescription);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#RegionID').val();
    $('#TerritoryTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../RegionDetail/GetTerritoryDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "TerritoryID" },
            { data: "TerritoryDescription" }
        ]
    });    
    GetDetails(id);
});