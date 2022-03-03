async function OpenDeleteModal() {
    if (partId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeletePart() {
    let PartId = partId == null ? 0 : parseInt(partId);
    if (PartId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }

    $.ajax({
        url: `/Part/DeletePart`,
        type: "POST",
        data: {
            partId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadPartGrid();
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