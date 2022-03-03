async function OpenDeleteModal() {
    if (destinationId != 0) {
        $("#confirmToDeleteModal").modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
}

async function DeleteDestination() {
    let DestinationId = destinationId == null ? 0 : parseInt(destinationId);
    if (DestinationId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }

    $.ajax({
        url: `/Destination/DeleteDestination`,
        type: "DELETE",
        data: {
            destinationId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadDestinationGrid();
                return true;
            }
            else {
                ErrorAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                return false;
            }
        })

        .fail(function () {
            ErrorAlert(`Lỗi hệ thống - Vui lòng liên hệ IT.`);
            $(`#confirmToDeleteModal`).modal(`hide`);
            return false;
        });
}
