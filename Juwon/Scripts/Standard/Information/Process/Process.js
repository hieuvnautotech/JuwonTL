﻿/** view */
const modifyBtn = document.getElementById(`modifyBtn`);
const deleteBtn = document.getElementById(`deleteBtn`);
const searchBtn = document.getElementById(`searchBtn`);
const searchInput = document.getElementById(`searchInput`);
const showDeleted = document.getElementById(`showDeleted`);
const $processGrid = $(`#processGrid`);

/** create */
const cProcessCode = document.getElementById(`cProcessCode`);
const cProcessName = document.getElementById(`cProcessName`);
const cProcessDescription = document.getElementById(`cProcessDescription`);
const cProcessNote = document.getElementById(`cProcessNote`);
const btnConfirmToCreate = document.getElementById(`btnConfirmToCreate`);

/** modify */
const mProcessCode = document.getElementById(`mProcessCode`);
const mProcessName = document.getElementById(`mProcessName`);
const mProcessDescription = document.getElementById(`mProcessDescription`);
const mProcessNote = document.getElementById(`mProcessNote`);
const btnConfirmToModify = document.getElementById(`btnConfirmToModify`);

/** delete */
const btnConfirmToDelete = document.getElementById(`btnConfirmToDelete`);

var processId = 0;

async function Initialize() {
    await ProcessGrid();
    await ReloadProcessGrid();
}

$(`#searchInput`).on(`keypress`, function (e) {
    if (e.which == 13) {
        $(`#searchBtn`).trigger(`click`);
    }
});

//PROCESS GRID
async function ProcessGrid() {
    "use strict";
    $processGrid.jqGrid({
        colModel: [
            { name: "ProcessId", label: "", key: true, hidden: true },
            { name: "ProcessCode", width: 200, align: 'center', searchoptions: { sopt: ['cn'] } },
            { name: "ProcessName", label: "Name", width: 100, align: 'center', search: false },
            { name: "ProcessDescription", label: "Description", width: 100, align: 'center', search: false },
            { name: "ProcessNote", label: "Note", width: 100, align: 'center', search: false },
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
            //{ name: "CreatedBy", label: "Created By", width: 100, align: 'center', search: false },
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
            //{ name: "ModifiedBy", label: "Modified By", width: 100, align: 'center', search: false },
            { name: "Active", label: "Actived", hidden: true, align: 'center', formatter: ShowActiveStatus },
        ],
        jsonReader:
        {
            root: "result",
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
            $(`#gbox_processGrid`).block({
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
        caption: 'Process',
        loadComplete: function () {
            $(`#gbox_processGrid`).unblock();
            let ids = $processGrid.getDataIDs();
            for (let i of ids) {
                let row = $processGrid.getRowData(i);
                if (row.Active === "NO") {
                    $processGrid.setCell(i, 'ProcessCode', '', { 'background-color': '#ffcc99' }, '');
                    $processGrid.setCell(i, 'ProcessName', '', { 'background-color': '#ffcc99' }, '');
                }
            }
        },
        onSelectRow: function (rowid, status, e, iRow, iCol) {
            if (parseInt(rowid) == processId) {
                processId = 0;
            }
            else {
                processId = parseInt(rowid);
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

//RELOAD PROCESS GRID
async function ReloadProcessGrid() {
    return new Promise(resolve => {
        let keyWord = searchInput.value == null ? "" : searchInput.value;
        let requestUrl = ``;
        if (showDeleted.checked) {
            requestUrl = `/Process/SearchAll?keyWord=${keyWord}`;
        }
        else {
            requestUrl = `/Process/Search?keyWord=${keyWord}`;
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
                        $processGrid
                            .clearGridData()
                            .setGridParam({
                                data: response.Data === null ? "" : response.Data,
                                datatype: 'local',
                            }).trigger(`reloadGrid`);
                        processId = 0;
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
