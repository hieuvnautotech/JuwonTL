async function OpenDeleteModal() {
    if (moldId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeleteMold() {
    let MoldId = moldId == null ? 0 : parseInt(moldId);
    if (MoldId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }

    $.ajax({
        url: `/Mold/DeleteMold`,
        type: "DELETE",
        data: {
            moldId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadMoldGrid();
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