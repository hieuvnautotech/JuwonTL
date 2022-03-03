async function CreateMold() {
    let moldCode = cMoldCode.value;
    let moldName = cMoldName.value;
    let UnitPrice = cMoldUnitPrice.value;


    if (!moldName || moldName.trim().length === 0) {
        WarningAlert(`ERROR_FullFillTheForm`);
        return false;
    }

    let obj = {
        moldCode,
        moldName,
        UnitPrice,

    }

    $.ajax({
        url: `/Mold/CreateMold`,
        type: "POST",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditonal: true,
        cache: false,
    })
        .done(function (response) {
            if (response.Data && response.HttpResponseCode != 100) {
                $moldGrid.addRowData(response.Data.MoldId, response.Data, `first`);
                $moldGrid.setRowData(response.Data.MoldId, false, { background: '#39FF14' });
                SuccessAlert(response.ResponseMessage);
                $(`#confirmToCreateModal`).modal(`hide`);
                $(`#createModal`).modal(`hide`);
                return true;
            }
            else {
                ErrorAlert(response.ResponseMessage);
                $(`#confirmToCreateModal`).modal(`hide`);
                return false;
            }
        })

        .fail(function () {
            ErrorAlert(`Lỗi hệ thống - Vui lòng liên hệ IT.`);
            $(`#confirmToCreateModal`).modal(`hide`);
            return false;
        });
}