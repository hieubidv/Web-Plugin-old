
function GetDetails(id) {
    $.ajax({
        url: "/UserTable/GetDetail/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#UserId').val(response.UserId);
            $('#UserName').val(response.UserName);
            $('#Email').val(response.Email);
            $('#Password').val(response.Password);
            $('#FirstName').val(response.FirstName);
            $('#LastName').val(response.LastName);
            $('#PhoneNumber').val(response.PhoneNumber);
            $('#BirthDay').val(moment(response.BirthDay).format('DD/MM/YYYY'));
            $('#IpAddress').val(response.IpAddress);
            $('#Status').val(response.Status);
            $('#CreateDate').val(moment(response.CreateDate).format('DD/MM/YYYY'));
            $('#RoomRoomId').val(response.RoomRoomId);
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
                "UserId": {           
                    required: true                                                       
             
                }
             ,                                   
                "UserName": {           
                    required: true                                                       
             
                }
             ,                                   
                "Email": {           
                    required: true                                                       
             
                }
             ,                                   
                "Password": {           
                    required: true                                                       
             
                }
             ,                                   
                "FirstName": {           
                    required: true                                                       
             
                }
             ,                                   
                "LastName": {           
                    required: true                                                       
             
                }
             ,                                   
                "PhoneNumber": {           
                    required: true                                                       
             
                }
             ,                                   
                "BirthDay": {           
                    required: true                                                       
             
                }
             ,                                   
                "IpAddress": {           
                    required: true                                                       
             
                }
             ,                                   
                "Status": {           
                    required: true                                                       
             
                }
             ,                                   
                "CreateDate": {           
                    required: true                                                       
             
                }
             ,                                   
                "RoomId": {           
                }
                                                
            },
            messages:
                {
                "UserId": {           
             
            						
                }
             ,                                   
                "UserName": {           
             
            						
                }
             ,                                   
                "Email": {           
             
            						
                }
             ,                                   
                "Password": {           
             
            						
                }
             ,                                   
                "FirstName": {           
             
            						
                }
             ,                                   
                "LastName": {           
             
            						
                }
             ,                                   
                "PhoneNumber": {           
             
            						
                }
             ,                                   
                "BirthDay": {           
             
            						
                }
             ,                                   
                "IpAddress": {           
             
            						
                }
             ,                                   
                "Status": {           
             
            						
                }
             ,                                   
                "CreateDate": {           
             
            						
                }
             ,                                   
                "RoomId": {           
                }
                                                
                }
        });

    var table = $('#mainTable').DataTable({
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"html5buttons"B><"col-sm-1">l><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '/UserTable/GetAllRows',
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
            "targets": [7,10],
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
            { data: "UserName" },
            { data: "Email" },
            { data: "Password" },
            { data: "FirstName" },
            { data: "LastName" },
            { data: "PhoneNumber" },
            { data: "BirthDay" },
            { data: "IpAddress" },
            { data: "Status" },
            { data: "CreateDate" },
            {
                data: "UserId",
                render: function (data, type, full, meta) {
                    return "<button type=\"button\" key=" + data + " class=\"btn btn-success btn-sm\" onclick=\"ShowModal(this)\"><i class=\"fa fa-edit\"></i></button>";
                }
            },
            {
                data: "UserId",
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

    $('#BirthDay').datepicker({
        language: "vi",
        autoclose: true,
        format: "dd/mm/yyyy"
    }).on('show.bs.modal', function (event) {
        event.stopPropagation();
    });
    $('#CreateDate').datepicker({
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
            _url = 'UserTable/Create'
        } else {
            _url = 'UserTable/Update'
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
            $('#UserId').val('');
            $('#UserName').val('');
            $('#Email').val('');
            $('#Password').val('');
            $('#FirstName').val('');
            $('#LastName').val('');
            $('#PhoneNumber').val('');
            $('#BirthDay').val(moment(Date.now()).format('DD/MM/YYYY'));
            $('#IpAddress').val('');
            $('#Status').val('');
            $('#CreateDate').val(moment(Date.now()).format('DD/MM/YYYY'));
            $('#RoomId').val('');
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
                        url: 'UserTable/Delete',
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
            url: 'UserTable/UploadFile',
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

