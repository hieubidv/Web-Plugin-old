var listUser = [];
var listRole = [];
var listRoleSelected = [];
var listOption = "";




$(document).ready(function () {
  
    var demo2 = $('#duallistbox').bootstrapDualListbox({
        preserveSelectionOnMove: 'moved',
        nonSelectedListLabel: "Danh sách báo cáo",
        selectedListLabel: "Danh sách báo cáo đã phân cho CB",
        moveOnSelect: false,
        infoTextFiltered: true,
        infoText: ""
    });

    findAllRole();
    findAllUser();


    function findAllRole() {
        $.ajax({
            url: "/AddRoleToUser/GetAllRole/",
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (response) {
                listRole = response;
                listOption = "";
                for (var i = 0; i < listRole.length; i++) {
                    listOption += "<option value='" + listRole[i].Value + "'>"
                        + listRole[i].Text + "</option>";
                }
                $('#duallistbox').append(listOption);
                $("#duallistbox").bootstrapDualListbox('refresh');              
            },
            error: function (result) {
                console.log('ko lay dc thong tin danh sach nhom quyen');
            }
        });
    }

    function findAllUser() {
        $.ajax({
            url: "/AddRoleToUser/GetAllUser/",
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (response) {
                listUser = response;
                listOption = "";
                for (var i = 0; i < listUser.length; i++) {
                    listOption += "<option value='" + listUser[i].Value + "'>"
                        + listUser[i].Text + "</option>";
                }
                $('#userListBox').append(listOption);
                $('#userListBox').val(listUser[0]);
            },
            error: function (result) {
                console.log('ko lay dc thong tin danh sach nguoi dung');
            }
        });
    }


    $("#btnSave").click(function () {
        listRoleSelected = $('#duallistbox').val();
        var selectedUser = $('#userListBox').val();  
        if (listRoleSelected == null) {
            listRoleSelected = [];
        }
        $.ajax({
            type: 'POST',
            url: "/AddRoleToUser/Save/",
            cache: false,
            traditional: true,
            data: {                
                selected: listRoleSelected,
                key: selectedUser
            },
            success: function (response) {            
                if (Object.keys(response.Errors).length > 0) {
                    bootbox.alert('Da co loi khi ghi thong tin');
                } else {
                    bootbox.alert('Ghi thanh cong');
                }
               
            },
            error: function (result) {
                bootbox.alert('Da co loi xay ra');
            }
        });


    });


    $('#userListBox').change(function () {    
        loadSelectedRole();
    });

    function loadSelectedRole() {
        var selectedUser = $('#userListBox').val();       
        if (selectedUser == "") {
            return null;
        } else {
            $.ajax({
                type: 'POST',
                url: "/AddRoleToUser/LoadSelectedRole/",
                cache: false,
                data: { key: selectedUser },
                success: function (response) {
                    $('#duallistbox').val(response);                
                    $("#duallistbox").bootstrapDualListbox('refresh',true);
                },
                error: function (result) {
                   alert('ko lay dc thong tin');
                }
            });
        }

    };


});




