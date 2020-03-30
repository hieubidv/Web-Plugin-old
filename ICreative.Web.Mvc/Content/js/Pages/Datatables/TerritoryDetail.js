
function GetDetails(id) {
    $.ajax({
        url: '../../TerritoryDetail/GetTerritory/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#TerritoryID').text(response.TerritoryID);        					
            $('#TerritoryDescription').text(response.TerritoryDescription);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#TerritoryID').val();
    $('#EmployeeTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../TerritoryDetail/GetEmployeeDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "EmployeeID" },
            { data: "LastName" },
            { data: "FirstName" },
            { data: "Title" },
            { data: "TitleOfCourtesy" },
            { data: "BirthDate" },
            { data: "HireDate" },
            { data: "Address" },
            { data: "City" },
            { data: "Region" },
            { data: "PostalCode" },
            { data: "Country" },
            { data: "HomePhone" },
            { data: "Extension" },
            { data: "Photo" },
            { data: "Notes" },
            { data: "PhotoPath" }
        ]
    });    
    GetDetails(id);
});