﻿
function GetDetails(id) {
    $.ajax({
        url: "/PermissionTable/GetDetail/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#PermissionId').val(response.PermissionId);
            $('#PermissionName').val(response.PermissionName);
            $('#PermissionDescription').val(response.PermissionDescription);
            $('#ControllerName').val(response.ControllerName);
            $('#ActionName').val(response.ActionName);
            $('#IsAnonymous').val(response.IsAnonymous);
            $('#IsDefaultAllow').val(response.IsDefaultAllow);
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
                "PermissionId": {           
                    required: true                                                       
             
                }
             ,                                   
                "PermissionName": {           
                    required: true                                                       
             
                }
             ,                                   
                "PermissionDescription": {           
                    required: true                                                       
             
                }
             ,                                   
                "ControllerName": {           
                    required: true                                                       
             
                }
             ,                                   
                "ActionName": {           
                    required: true                                                       
             
                }
             ,                                   
                "IsAnonymous": {           
                    required: true                                                       
             
                }
             ,                                   
                "IsDefaultAllow": {           
                    required: true                                                       
             
                }
                                                
            },
            messages:
                {
                "PermissionId": {           
             
            						
                }
             ,                                   
                "PermissionName": {           
             
            						
                }
             ,                                   
                "PermissionDescription": {           
             
            						
                }
             ,                                   
                "ControllerName": {           
             
            						
                }
             ,                                   
                "ActionName": {           
             
            						
                }
             ,                                   
                "IsAnonymous": {           
             
            						
                }
             ,                                   
                "IsDefaultAllow": {           
             
            						
                }
                                                
                }
        });

    var table = $('#mainTable').DataTable({
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"html5buttons"B><"col-sm-1">l><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '/PermissionTable/GetAllRows',
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
        }
        ],
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "PermissionName" },
            { data: "PermissionDescription" },
            { data: "ControllerName" },
            { data: "ActionName" },
            { data: "IsAnonymous" },
            { data: "IsDefaultAllow" },
            {
                data: "PermissionId",
                render: function (data, type, full, meta) {
                    return "<button type=\"button\" key=" + data + " class=\"btn btn-success btn-sm\" onclick=\"ShowModal(this)\"><i class=\"fa fa-edit\"></i></button>";
                }
            },
            {
                data: "PermissionId",
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


    $('#mainForm').on('submit', function (event) {
        event.preventDefault()
        var _url = '';
        if ($('#mainModal').data('mode') == 'create') {
            _url = 'PermissionTable/Create'
        } else {
            _url = 'PermissionTable/Update'
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
            $('#PermissionId').val('');
            $('#PermissionName').val('');
            $('#PermissionDescription').val('');
            $('#ControllerName').val('');
            $('#ActionName').val('');
            $('#IsAnonymous').val('');
            $('#IsDefaultAllow').val('');
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
                        url: 'PermissionTable/Delete',
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
            url: 'PermissionTable/UploadFile',
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

