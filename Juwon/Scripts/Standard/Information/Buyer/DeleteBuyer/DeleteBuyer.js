async function OpenDeleteModal() {
    if (buyerId != 0) {
        $(`#confirmToDeleteModal`).modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }
};

async function DeleteBuyer() {
    let BuyerId = buyerId == null ? 0 : parseInt(buyerId);
    if (BuyerId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }

    $.ajax({
        url: `/Buyer/DeleteBuyer`,
        type: "DELETE",
        data: {
            buyerId
        },
    })
        .done(function (response) {
            if (response.IsSuccess) {
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToDeleteModal`).modal(`hide`);
                searchInput.value == null;
                ReloadBuyerGrid();
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