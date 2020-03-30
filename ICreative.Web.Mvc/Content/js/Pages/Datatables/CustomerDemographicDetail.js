
function GetDetails(id) {
    $.ajax({
        url: '../../CustomerDemographicDetail/GetCustomerDemographic/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#CustomerTypeID').text(response.CustomerTypeID);        					
            $('#CustomerDesc').text(response.CustomerDesc);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#CustomerTypeID').val();
    $('#CustomerTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../CustomerDemographicDetail/GetCustomerDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "CustomerID" },
            { data: "CompanyName" },
            { data: "ContactName" },
            { data: "ContactTitle" },
            { data: "Address" },
            { data: "City" },
            { data: "Region" },
            { data: "PostalCode" },
            { data: "Country" },
            { data: "Phone" },
            { data: "Fax" }
        ]
    });    
    GetDetails(id);
});