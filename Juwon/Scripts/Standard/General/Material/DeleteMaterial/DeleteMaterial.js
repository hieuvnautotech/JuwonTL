async function OpenDeleteModal() {
    if (locationCategoryId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeleteLocationCategory() {
    let LocationCategoryId = locationCategoryId == null ? 0 : parseInt(locationCategoryId);
    if (LocationCategoryId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }

    $.ajax({
        url: `/LocationCategory/DeleteLocationCategory`,
        type: "DELETE",
        data: {
            locationCategoryId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadLocationCategoryGrid();
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