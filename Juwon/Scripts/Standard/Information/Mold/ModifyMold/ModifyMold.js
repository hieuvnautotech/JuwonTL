

async function OpenModifyModal() {
    if (moldId != 0) {
        let obj = $moldGrid.getRowData(moldId);
        mMoldCode.value = obj.MoldCode;
        mMoldName.value = obj.MoldName;
        mMoldUnitPrice.value = obj.UnitPrice;
        $("#modifyModal").modal();
    }
    else {
        WarningAlert(`WARN_NotSelectOnGrid`);
    }
    return;
}

async function ModifyMold() {

    let MoldId = moldId == null ? 0 : parseInt(moldId);
    let MoldName = mMoldName.value;
    let UnitPrice = mMoldUnitPrice.value;

    if (MoldId == 0) {
        WarningAlert(`WARN_NotSelectOnGrid`);
        return false;
    }

    if (!MoldName || MoldName.trim().length === 0) {
        WarningAlert(`ERROR_FullFillTheForm`);
        return false;
    }

    let obj = {
        MoldId,
        MoldName,
        UnitPrice
    }

    $.ajax({
        url: `/Mold/ModifyMold`,
        type: "PUT",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditonal: true,
        cache: false,
    })
        .done(function (response) {
            if (response.Data && response.HttpResponseCode != 100) {
                $moldGrid.setRowData(response.Data.MoldId, response.Data);
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToModifyModal`).modal(`hide`);
                $(`#modifyModal`).modal(`hide`);
                return true;
            }
            else {
                ErrorAlert(response.ResponseMessage);
                $(`#confirmToModifyModal`).modal(`hide`);
                return false;
            }
        })

        .fail(function () {
            ErrorAlert(`Lỗi hệ thống - Vui lòng liên hệ IT.`);
            $(`#confirmToModifyModal`).modal(`hide`);
            return false;
        });
}