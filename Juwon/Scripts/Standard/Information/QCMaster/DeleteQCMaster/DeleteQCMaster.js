async function OpenDeleteModal() {
    if (qcMasterId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeleteQCMaster() {
    let QCMasterId = qcMasterId == null ? 0 : parseInt(qcMasterId);
    if (QCMasterId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }

    $.ajax({
        url: `/QCMaster/DeleteQCMaster`,
        type: "DELETE",
        data: { qcMasterId },

    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadQCMasterGrid();
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