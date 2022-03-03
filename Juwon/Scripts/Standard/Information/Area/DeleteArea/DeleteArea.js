async function OpenDeleteModal() {
    if (areaId != 0) {
        $("#confirmToDeleteModal").modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
}

async function DeleteArea() {
    let AreaId = areaId == null ? 0 : parseInt(areaId);
    if (AreaId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }

    $.ajax({
        url: `/Area/DeleteArea`,
        type: "DELETE",
        data: {
            areaId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchBtn.value == null;
                ReloadAreaGrid();
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