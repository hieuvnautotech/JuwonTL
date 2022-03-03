async function OpenDeleteModal() {
    if (colorId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeleteColor() {
    let ColorId = colorId == null ? 0 : parseInt(colorId);
    if (ColorId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }

    $.ajax({
        url: `/Color/DeleteColor`,
        type: "DELETE",
        data: {
            colorId
        },

    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadColorGrid();
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