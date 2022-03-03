/** view */
const modifyBtn = document.getElementById(`modifyBtn`);
const deleteBtn = document.getElementById(`deleteBtn`);
const searchBtn = document.getElementById(`searchBtn`);
const searchInput = document.getElementById(`searchInput`);
const showDeleted = document.getElementById(`showDeleted`);
const $materialGrid = $(`#materialGrid`);

/** create */
const cMaterialName = document.getElementById(`cMaterialName`);
const cMaterialInOut = document.getElementById(`cMaterialInOut`);
const cMaterialSection = document.getElementById(`cMaterialSection`);
const cMaterialType = document.getElementById(`cMaterialType`);
const cMaterialPart = document.getElementById(`cMaterialPart`);
const cMaterialColor = document.getElementById(`cMaterialColor`);
const cMaterialUnit = document.getElementById(`cMaterialUnit`);
const btnConfirmToCreate = document.getElementById(`btnConfirmToCreate`);

/** modify */
//const mLocationCategoryName = document.getElementById(`mLocationCategoryName`);
//const btnConfirmToModify = document.getElementById(`btnConfirmToModify`);

/** delete */
//const btnConfirmToDelete = document.getElementById(`btnConfirmToDelete`);

var materialId = 0;

async function Initialize() {
    await MaterialGrid();
    await ReloadMaterialGrid();
}

$(`#searchInput`).on(`keypress`, function (e) {
    if (e.which == 13) {
        $(`#searchBtn`).trigger(`click`);
    }
});

//MATERIAL GRID
async function MaterialGrid() {
    "use strict";
    $materialGrid.jqGrid({
        colModel: [
            { name: "MaterialId", label: "", key: true, hidden: true },
            { name: "MaterialTypeId", label: "", hidden: true },
            { name: "MaterialInOutId", label: "", hidden: true },
            { name: "MaterialSectionId", label: "", hidden: true },
            { name: "MaterialUnitId", label: "", hidden: true },
            { name: "PartId", label: "", hidden: true },
            { name: "ColorId", label: "", hidden: true },

            { name: "MaterialCode", label: "Code", width: 100, align: 'center', search: false },
            { name: "MaterialName", label: "Name", width: 200, align: 'center', search: false },
            { name: "MaterialTypeName", label: "Type", width: 50, align: 'center', search: false },
            { name: "MaterialInOutName", label: "IN/OUT", width: 50, align: 'center', search: false },
            { name: "MaterialSectionName", label: "Section", width: 50, align: 'center', search: false },
            { name: "MaterialUnitName", label: "Unit", width: 70, align: 'center', search: false },
            {
                name: "CreatedDate", width: 100, align: 'center', formatter: 'date', formatoptions:
                {
                    srcformat: "ISO8601Long", newformat: "Y-m-d"
                },
                sorttype: 'date',
                label: "Created Date",
                searchoptions: {
                    sopt: ['ge'],
                    dataInit: function (elem) {
                        $(elem).datepicker({
                            dateFormat: 'yy-mm-dd',
                            autoSize: true,
                            changeYear: true,
                            changeMonth: true,
                            showButtonPanel: true,
                            showWeek: true,
                            onSelect: function () {
                                $(this).keydown();
                            },
                        });
                    }
                }
            },
            {
                name: "ModifiedDate", width: 100, align: 'center', formatter: 'date', formatoptions:
                {
                    srcformat: "ISO8601Long", newformat: "Y-m-d"
                },
                sorttype: 'date',
                label: "ModifiedDate",
                searchoptions: {
                    sopt: ['ge'],
                    dataInit: function (elem) {
                        $(elem).datepicker({
                            dateFormat: 'yy-mm-dd',
                            autoSize: true,
                            changeYear: true,
                            changeMonth: true,
                            showButtonPanel: true,
                            showWeek: true,
                            onSelect: function () {
                                $(this).keydown();
                            },
                        });
                    }
                }
            },
            { name: "Active", label: "Actived", hidden: true, align: 'center', formatter: ShowActiveStatus },
        ],
        jsonReader:
        {
            root: "Data",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        iconSet: "fontAwesome",
        rownumbers: true,
        sortname: "Name",
        sortorder: "asc",
        threeStateSort: true,
        sortIconsBeforeText: true,
        headertitles: true,
        pager: true,
        rowNum: 20,
        viewrecords: true,
        shrinkToFit: false,
        height: 600,
        cmTemplate: { resizable: false },
        //loadui: 'disable',
        //footerrow: true,
        beforeRequest: function () {
            $(`#gbox_materialGrid`).block({
                message: '<img src="../../../Img/loading/hourglass.gif" />'
            });
        },
        beforeProcessing: function (data) {
            //var model = data.multiLangModel, name, $colHeader, $sortingIcons;
            //if (model)
            //{
            //    for (name in model)
            //    {
            //        if (model.hasOwnProperty(name))
            //        {
            //            $colHeader = $("#jqgh_" + $.jgrid.jqID(this.id + "_" + name));
            //            $sortingIcons = $colHeader.find(">span.s-ico");
            //            $colHeader.text(model[name].label);
            //            $colHeader.append($sortingIcons);
            //        }
            //    }
            //}
        },
        loadonce: true,
        caption: 'Material',
        loadComplete: function () {
            $(`#gbox_materialGrid`).unblock();
            let ids = $materialGrid.getDataIDs();
            for (let i of ids) {
                let row = $materialGrid.getRowData(i);
                if (row.Active === "NO") {
                    $materialGrid.setCell(i, 'LocationCategoryName', '', { 'background-color': '#ffcc99' }, '');
                }
            }
        },
        onSelectRow: function (rowid, status, e, iRow, iCol) {
            if (parseInt(rowid) == materialId) {
                materialId = 0;
            }
            else {
                materialId = parseInt(rowid);
            }
        }
    })
        .filterToolbar({
            searchOperators: true,
            searchOnEnter: false,
            loadFilterDefaults: false,
            afterSearch: function () {
            }
        });
}

//RELOAD MATERIAL GRID
async function ReloadMaterialGrid() {
    return new Promise(resolve => {
        let keyWord = searchInput.value == null ? "" : searchInput.value;
        let requestUrl = ``;
        if (showDeleted.checked) {
            requestUrl = `/Material/SearchAll?keyWord=${keyWord}`;
        }
        else {
            requestUrl = `/Material/SearchActive?keyWord=${keyWord}`;
        }
        $.ajax({
            url: requestUrl,
            type: `GET`,
        })
            .done(function (response) {
                if (response) {
                    if (response.HttpResponseCode == 100) {
                        WarningAlert(response.ResponseMessage);
                    }
                    else {
                        $materialGrid
                            .clearGridData()
                            .setGridParam({
                                data: response.Data === null ? "" : response.Data,
                                datatype: 'local',
                            }).trigger(`reloadGrid`);
                        materialId = 0;
                    }

                    resolve(true);
                }
            })
            .fail(function () {
                ErrorAlert(`System error - Please contact IT`);
                resolve(false);
            })
    })
}

async function GetMaterialSections() {
    $.ajax({
        url: `/Material/GetMaterialSections`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.Name < b.Name) return -1
                    return a.Name > b.Name ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.ID}">${item.Name}</option>`;
                });
                $(`#cMaterialSection`).html(html);
                //$(`#mMaterialSection`).html(html);
            }
        });
}

async function GetMaterialUnits() {
    $.ajax({
        url: `/Material/GetMaterialUnits`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.Name < b.Name) return -1
                    return a.Name > b.Name ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.ID}">${item.Name}</option>`;
                });
                $(`#cMaterialUnit`).html(html);
                //$(`#mMaterialUnit`).html(html);
            }
        });
}

async function GetMaterialInOut() {
    $.ajax({
        url: `/Material/GetMaterialInOut`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.Name < b.Name) return -1
                    return a.Name > b.Name ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.ID}">${item.Name}</option>`;
                });
                $(`#cMaterialInOut`).html(html);
                //$(`#mMaterialInOut`).html(html);
            }
        });
}

async function GetMaterialType() {
    $.ajax({
        url: `/Material/GetMaterialType`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.Name < b.Name) return -1
                    return a.Name > b.Name ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.ID}">${item.Name}</option>`;
                });
                $(`#cMaterialType`).html(html);
                //$(`#mMaterialType`).html(html);
            }
        });
}

async function GetMaterialPart() {
    $.ajax({
        url: `/Material/GetMaterialPart`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.PartName < b.PartName) return -1
                    return a.PartName > b.PartName ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.PartId}">${item.PartName}</option>`;
                });
                $(`#cMaterialPart`).html(html);
                //$(`#mMaterialPart`).html(html);
            }
        });
}

async function GetMaterialColor() {
    $.ajax({
        url: `/Material/GetMaterialColor`,
    })
        .done(function (response) {
            let html = ``;
            if (response.Data.length > 0) {
                response.Data.sort((a, b) => {
                    if (a.ColorName < b.ColorName) return -1
                    return a.ColorName > b.ColorName ? 1 : 0
                });


                $.each(response.Data, function (key, item) {
                    html += `<option value="${item.ColorId}">${item.ColorName}</option>`;
                });
                $(`#cMaterialColor`).html(html);
                //$(`#mMaterialColor`).html(html);
            }
        });
}