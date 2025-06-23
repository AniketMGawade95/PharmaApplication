$(document).ready(function () {
    //FetchEmployee();
    $("#closebtnn").click(function () {
        $("#exampleModal").modal('hide');
    });


});


$("#rolemodal").click(function () {
    $("#exampleModal").modal('show');
});












$("#savebtn").click(function () {
    var obj = $("#RoleForm").serialize();

    $.ajax({

        url: "/Admin/AddRole",
        type: "Post",
        datatype: "json",
        contentType: "Application/x-www-form-urlencoded;charset=utf-8",
        data: obj,
        success: function () {
            alert("Role Added Successfully");
            $("#exampleModal").modal('hide');
            //FetchEmployee();
        },
        error: function () {
            alert("Error");
        }

    });
});




//$("#savebtn").click(function () {
//    var obj = $("#RoleForm").serialize();
//    var id = $("#empIdHidden").val();

//    var url = id ? "/Ajax/UpdateEmployee" : "/Ajax/AddEmp";

//    $.ajax({
//        url: url,
//        type: "POST",
//        datatype: "json",
//        contentType: "application/x-www-form-urlencoded;charset=utf-8",
//        data: obj,
//        success: function () {
//            alert(id ? "Employee Updated" : "Employee Added");
//            $("#exampleModal").modal('hide');
//            FetchEmployee();


//            $("#EmpForm")[0].reset();
//            $("#empIdHidden").val("");
//            $("#savebtn").text("Save");
//        },
//        error: function () {
//            alert("Error");
//        }
//    });
//});















//function FetchEmployee() {
//    $.ajax({

//        url: "/Ajax/FetchEmployee",
//        type: "Get",
//        datatype: "json",
//        contentType: "Application/json;charset=utf-8",

//        success: function (result) {

//            var obj = '';
//            $.each(result, function (index, item) {
//                obj += '<tr>';
//                obj += '<td>' + item.empID + '</td>';
//                obj += '<td>' + item.empName + '</td>';
//                obj += '<td>' + item.empSalary + '</td>';
//                obj += '<td>' + item.empEmailId + '</td>';
//                obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteEmp(' + item.empID + ')">Delete</a></td>';
//                obj += '<td><a class="btn btn-sm btn-info" onclick="UpdateEmp(' + item.empID + ')">Update</a></td>';
//                obj += '</tr>';
//            });
//            $("#empdata").html(obj);
//        },
//        error: function () {
//            alert("Not Found");
//        }

//    });
//}


//$("#txt").keyup(function () {
//    var data = $("#txt").val();

//    $.ajax({

//        url: "/Ajax/SearchEmployee?name=" + data,
//        type: "Get",
//        datatype: "json",
//        contentType: "Application/json;charset=utf-8",

//        success: function (result) {

//            var obj = '';
//            $.each(result, function (index, item) {
//                obj += '<tr>';
//                obj += '<td>' + item.empID + '</td>';
//                obj += '<td>' + item.empName + '</td>';
//                obj += '<td>' + item.empSalary + '</td>';
//                obj += '<td>' + item.empEmailId + '</td>';
//                obj += '</tr>';
//            });
//            $("#empdata").html(obj);
//        },
//        error: function () {
//            alert("Not Found");
//        }

//    });


//});


//function DeleteEmp(id) {

//    if (confirm("Are You Sure?")) {
//        $.ajax({
//            url: "/Ajax/DeleteEmployee?eid=" + id,
//            success: function () {
//                FetchEmployee();
//            },
//            error: function () {

//            }

//        });
//    }
//    else {
//        alert("Data Not Deleted");
//    }

//}




//function UpdateEmp(id) {
//    $.ajax({
//        url: "/Ajax/GetEmployeeById?eid=" + id,
//        type: "GET",
//        datatype: "json",
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {

//            $("#empIdHidden").val(data.empID);
//            $("#empName").val(data.empName);
//            $("#empSalary").val(data.empSalary);
//            $("#empEmailId").val(data.empEmailId);


//            $("#exampleModal").modal('show');


//            $("#savebtn").text("Update");
//        },
//        error: function () {
//            alert("Error loading employee");
//        }
//    });
//}




