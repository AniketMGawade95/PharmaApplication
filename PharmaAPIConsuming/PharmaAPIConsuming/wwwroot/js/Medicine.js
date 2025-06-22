//pageload
$(document).ready(function () {
    loadData();

    // to open modal
    $("#addbtn").click(function () {
        clearForm();
        $("#exampleModal").modal("show");
    });

    // to save data added medicine
    $("#savebtn").click(function () {

        // validation 
        const isValid = document.querySelector("#medicineForm").reportValidity();
        if (isValid) {
            saveMedicine();
        }

    });
});

// save medicine
function saveMedicine() {
    var id = $('#MedicineId').val();

    // getting all together form data by seralize
    //var data = $("#medicineForm").serialize()

    var medicine = {
        name: $('#Name').val(),
        category: $('#Category').val(),
        gstRate: parseFloat($('#GSTRate').val())
    };

    if (id === "") {
        // Add
        $.ajax({
            url: '/Medicine/AddMedicine',
            type: 'POST',
            //dataType: 'Json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: medicine,
            success: function () {
                toastr.success("Medicine Added");
                $("#exampleModal").modal('hide');
                loadData();
            },
            error: function () {
                toastr.error("Medicine not added");
            }
        });
    } else {
        // Update
        var updatedMedicine = {
            medicineId: parseInt(id),
            name: medicine.name,
            category: medicine.category,
            gstRate: medicine.gstRate,
            updatedBy: 'Admin',
            updatedAt: new Date().toISOString()
        };
        //var updatedData = {
        //    medicineId: parseInt(medicineId),
        //    name: $('#name').val(),
        //    category: $('#category').val(),
        //    gstRate: parseFloat($('#gSTRate').val()),
        //    //updatedBy: "Admin",
        //    //updatedAt: new Date().toISOString()
        //};
        $.ajax({
            //url: `/Medicine/UpdateMedicine/${updatedMedicine.medicineId}`,
            url: `Medicine/UpdateMedicine`,
            type: 'PUT',
            //dataType: 'Json',
            contentType: 'application/json',
            data: JSON.stringify(updatedMedicine),
            success: function () {
                toastr.success("Medicine Updated");
                $("#exampleModal").modal('hide');
                loadData();
            },
            error: function () {
                toastr.error("Medicine not Updated");
            }
        });
    }
}



// fetch all
function loadData() {
    $.ajax({
        url: '/Medicine/GetAllMedicine',
        type: 'GET',
        //dataType: 'Json',
        //contentType: 'Application/json;charset=UTF-8', // for dql
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += `<tr>
                    <td>${item.medicineId}</td>
                    <td>${item.name}</td>
                    <td>${item.category}</td>
                    <td>${item.gstRate}</td>
                    <td>${item.createdBy || ''}</td>
                    <td>${formatDate(item.createdAt)}</td>
                    <td>${item.updatedBy || ''}</td>
                    <td>${formatDate(item.updatedAt)}</td>
                    <td>
                        <button class="btn btn-info btn-sm" onclick="editMedicine(${item.medicineId})">
                            <i class="bi bi-pencil-square"></i>
                        </button>
                        <button class="btn btn-danger btn-sm" onclick="deleteMedicine(${item.medicineId})">
                            <i class="bi bi-trash"></i>
                        </button>
                    </td>
                </tr>`;
            });
            $('#medicineTable').html(rows);
        },
        error: function () {
            toastr.error("Could not load data");
        }
    });
}

function editMedicine(id) {
    $.get(`/Medicine/GetMedicineById/${id}`, function (data) {
        $('#MedicineId').val(data.medicineId);
        $('#Name').val(data.name);
        $('#Category').val(data.category);
        $('#GSTRate').val(data.gstRate);
        $('#exampleModal').modal('show');
    });
}

function deleteMedicine(id) {
    if (confirm("Are you sure?")) {
        $.ajax({
            url: `/Medicine/DeleteMedicine/${id}`,
            type: 'DELETE',
            success: function () {
                toastr.error("Deleted");
                loadData();
            },
            error: function () {
                toastr.error("Delete failed");
            }
        });
    }
}

function clearForm() {
    $('#MedicineId').val('');
    $('#Name').val('');
    $('#Category').val('');
    $('#GSTRate').val('');
}

// Format date safely
function formatDate(date) {
    if (!date) return "";
    return new Date(date).toLocaleString('en-IN');
}

