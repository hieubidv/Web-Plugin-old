
function GetDetails(id) {
    $.ajax({
        url: "/EmployeeTable/GetDetail/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#EmployeeID').val(response.EmployeeID);
            $('#LastName').val(response.LastName);
            $('#FirstName').val(response.FirstName);
            $('#Title').val(response.Title);
            $('#TitleOfCourtesy').val(response.TitleOfCourtesy);
            $('#BirthDate').val(moment(response.BirthDate).format('DD/MM/YYYY'));
            $('#HireDate').val(moment(response.HireDate).format('DD/MM/YYYY'));
            $('#Address').val(response.Address);
            $('#City').val(response.City);
            $('#Region').val(response.Region);
            $('#PostalCode').val(response.PostalCode);
            $('#Country').val(response.Country);
            $('#HomePhone').val(response.HomePhone);
            $('#Extension').val(response.Extension);
            $('#Photo').val(response.Photo);
            $('#Notes').val(response.Notes);
            $('#EmployeeReferenceEmployeeID').val(response.EmployeeReferenceEmployeeID);
            $('#PhotoPath').val(response.PhotoPath);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

function ShowModal(obj) {
    var rowID = $(obj).attr('key');
    $('#mainModal').data('id', rowID);
    $('#mainModal').data('mode', 'update');
    $('#mainModal').modal();
}

$(document).ready(function () {

	$('.custom-file-input').on('change', function() {
	   let fileName = $(this).val().split('\\').pop();
	   $(this).next('.custom-file-label').addClass("selected").html(fileName);
	});                   	
                  	
    var validattor = $('#mainForm').validate(
        {
            errorClass: 'border-danger',
            highlight: function (element, errorClass) {
                $(element).closest('.form-control').addClass(errorClass);
            },
            unhighlight: function (element, errorClass) {
                $(element).closest('.form-control').removeClass(errorClass);
            },
            rules: {
                "EmployeeID": {           
                    required: true                                                       
             
                }
             ,                                   
                "LastName": {           
                    required: true                                                       
             
                }
             ,                                   
                "FirstName": {           
                    required: true                                                       
             
                }
             ,                                   
                "Title": {           
                    required: true                                                       
             
                }
             ,                                   
                "TitleOfCourtesy": {           
                    required: true                                                       
             
                }
             ,                                   
                "BirthDate": {           
                    required: true                                                       
             
                }
             ,                                   
                "HireDate": {           
                    required: true                                                       
             
                }
             ,                                   
                "Address": {           
                    required: true                                                       
             
                }
             ,                                   
                "City": {           
                    required: true                                                       
             
                }
             ,                                   
                "Region": {           
                    required: true                                                       
             
                }
             ,                                   
                "PostalCode": {           
                    required: true                                                       
             
                }
             ,                                   
                "Country": {           
                    required: true                                                       
             
                }
             ,                                   
                "HomePhone": {           
                    required: true                                                       
             
                }
             ,                                   
                "Extension": {           
                    required: true                                                       
             
                }
             ,                                   
                "Photo": {           
                    required: true                                                       
             
                }
             ,                                   
                "Notes": {           
                    required: true                                                       
             
                }
             ,                                   
                "ReportsTo": {           
                }
             ,                                   
                "PhotoPath": {           
                    required: true                                                       
             
                }
                                                
            },
            messages:
                {
                "EmployeeID": {           
             
            						
                }
             ,                                   
                "LastName": {           
             
            						
                }
             ,                                   
                "FirstName": {           
             
            						
                }
             ,                                   
                "Title": {           
             
            						
                }
             ,                                   
                "TitleOfCourtesy": {           
             
            						
                }
             ,                                   
                "BirthDate": {           
             
            						
                }
             ,                                   
                "HireDate": {           
             
            						
                }
             ,                                   
                "Address": {           
             
            						
                }
             ,                                   
                "City": {           
             
            						
                }
             ,                                   
                "Region": {           
             
            						
                }
             ,                                   
                "PostalCode": {           
             
            						
                }
             ,                                   
                "Country": {           
             
            						
                }
             ,                                   
                "HomePhone": {           
             
            						
                }
             ,                                   
                "Extension": {           
             
            						
                }
             ,                                   
                "Photo": {           
             
            						
                }
             ,                                   
                "Notes": {           
             
            						
                }
             ,                                   
                "ReportsTo": {           
                }
             ,                                   
                "PhotoPath": {           
             
            						
                }
                                                
                }
        });

    var table = $('#mainTable').DataTable({
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"html5buttons"B><"col-sm-1">l><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '/EmployeeTable/GetAllRows',
        "autoWidth": false,
        "columnDefs": [
        {
            "searchable": false,
            "orderable": false,
            "targets": 0
        },
        {
            "searchable": false,
            "orderable": false,
            "targets": -2
        } ,
        {
            "searchable": false,
            "orderable": false,
            "targets": -3
        },
        {
            "targets": [5,6],
            "render": function (data) {
            return moment(data).format('DD/MM/YYYY'); }
        }
        ],
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
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
            { data: "Photo", 
                render: function (data, type, full, meta) {
                    return "<img src=\"data:image/jpeg;base64," + data + "\" />";
                }    
            },
            { data: "Notes" },
            { data: "PhotoPath" },
            {
                data: "EmployeeID",
                render: function (data, type, full, meta) {
                    return "<button type=\"button\" key=" + data + " class=\"btn btn-success btn-sm\" onclick=\"ShowModal(this)\"><i class=\"fa fa-edit\"></i></button>";
                }
            },
            {
                data: "EmployeeID",
                render: function (data, type, full, meta) {
                    return "<button type=\"button\"  key=" + data + " class=\"btn btn-danger btn-sm delete\" ><i class=\"fa fa-trash-o\"></i></button>";
                }
            },
        ],
        buttons: {
            dom: {
                button: {
                    className: 'btn btn-light'
                }
            },
            buttons: [
                {
                    text: 'Add',
                    action: function (e, dt, node, config) {
                        $('#mainModal').data('mode', 'create');
                        $('#mainModal').modal();
                    }
                },
                {
                    text: 'Import',
                    action: function (e, dt, node, config) {                     
                        $('#importModal').modal();
                    }                    
                },
                {
                    extend: 'csv',
                    columns: 'visible',
                    exportOptions: {
                        modifier: {
                            order: 'index'
                        }
                    }
                },
                {
                    text: 'Word',
                    action: function (e, dt, node, config) {
                        $('#mainModal').data('mode', 'create');
                        $('#mainModal').modal();
                    }
                },
                {
                    extend: 'print',
                    columns: 'visible',
                    exportOptions: {
                        modifier: {
                            order: 'index'
                        }
                    }
                }
            ]
        }
    });

    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            table.cell(cell).invalidate('dom');
        });
    }).draw();
    $('#mainTable').on('click', '.delete', function () {
        var rowID = $(this).attr('key');
        deleteData(rowID);
    });
    $('#mainModal').on('show.bs.modal', function () {
        var id = $('#mainModal').data('id');
        $('#input').blur(function () {
            validator.validate()
        });
        if ($('#mainModal').data('mode') == 'create') {
            clear();
        } else {
            GetDetails(id);
        }
    });

    $('#BirthDate').datepicker({
        language: "vi",
        autoclose: true,
        format: "dd/mm/yyyy"
    }).on('show.bs.modal', function (event) {
        event.stopPropagation();
    });
    $('#HireDate').datepicker({
        language: "vi",
        autoclose: true,
        format: "dd/mm/yyyy"
    }).on('show.bs.modal', function (event) {
        event.stopPropagation();
    });

    $('#mainForm').on('submit', function (event) {
        event.preventDefault()
        var _url = '';
        if ($('#mainModal').data('mode') == 'create') {
            _url = 'EmployeeTable/Create'
        } else {
            _url = 'EmployeeTable/Update'
        }
        if ($('#mainForm').valid()) {
            $.ajax({
                url: _url,
                type: 'POST',
                data: $(this).serialize()
            }).done(function (response) {
                if (Object.keys(response.Errors).length > 0) {
                    alert("Đã có lỗi khi ghi thông tin !!!!!!!")
                } else {
                    alert('Cập nhật thành công');
                    $('#mainModal').modal('hide');
                    table.ajax.reload();
                }
            }
            )
        } else {
            alert('Kiểm tra lại dữ liệu');
        }
    })

    $("#buttonCancel").click(function () {
        clear();
    });

    function clear() {
            $('#EmployeeID').val('');
            $('#LastName').val('');
            $('#FirstName').val('');
            $('#Title').val('');
            $('#TitleOfCourtesy').val('');
            $('#BirthDate').val(moment(Date.now()).format('DD/MM/YYYY'));
            $('#HireDate').val(moment(Date.now()).format('DD/MM/YYYY'));
            $('#Address').val('');
            $('#City').val('');
            $('#Region').val('');
            $('#PostalCode').val('');
            $('#Country').val('');
            $('#HomePhone').val('');
            $('#Extension').val('');
            $('#Photo').val('');
            $('#Notes').val('');
            $('#ReportsTo').val('');
            $('#PhotoPath').val('');
    }

    function deleteData(id) {
        bootbox.confirm({
            title: 'Remove User',
            message: 'Are you sure want to delete this record?',
            buttons: {
                'cancel': {
                    label: 'No',
                    className: 'btn-default pull-right'
                },
                'confirm': {
                    label: 'Yes',
                    className: 'btn-primary margin-right-5'
                }
            },
            callback: function (result) {
                if (result) {
                    //  $('#ibox1').toggleClass('sk-loading');
                    $.ajax({
                        url: 'EmployeeTable/Delete',
                        type: 'POST',
                        data: JSON.stringify({
                            "id": id
                        }),
                        contentType: 'application/json; charset=utf-8;'
                    }).done(function (response) {
                        // phải khơi tạo Errors list nếu không sẽ lỗi
                        if (Object.keys(response.Errors).length > 0) {
                            alert("Đã có lỗi khi xóa thông tin !!!!!!!")
                        } else {
                            table.ajax.reload();;
                        }
                    });
                }
            }
        });
    }
                  	
                  	
    $('#upload').on('click', function () {
        var form = $('#importForm')[0];
        var formdata = false;
        if (window.FormData) {
            formdata = new FormData(form);
        }
        $.ajax({
            url: 'EmployeeTable/UploadFile',
            data: formdata ? formdata : form.serialize(),
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (data, textStatus, jqXHR) {
                // Callback code
            }
        });
    });
                  	
                  	
});

