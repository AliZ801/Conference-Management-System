jQuery.noConflict()(function ($) {
    $(document).ready(function () {
        loadDataTable();
    })
})

var dataTable;

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/STag/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "sessions.title", "width": "35%" },
            { "data": "tags.name", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/STag/AddSTag/${data}" class="btn btn-primary text-white" style="cursor:pointer; width:110px">
                            <i class="fas fa-edit" style="color:white"></i> &nbsp; Update
                        </a>
                        &nbsp;
                        <a onclick=Delete("/Admin/STag/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:110px">
                            <i class="fas fa-trash-alt" style="color:white"></i> &nbsp; Delete
                        </a>
                    </div>`;
                },
                "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "No Record Found!"
        },
        "width": "100%"
    })
}

function Delete(url) {
    swal({
        title: "ARE YOU SURE YOU WANT TO DELETE IT?",
        text: "YOU WILL NOT BE ABLE TO RESTORE IT!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#BD6B55",
        confirmButtonText: "YES, DELETE IT!",
        closeOnConfirm: true
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    )
}