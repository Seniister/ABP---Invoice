
var InvoiceModal = new abp.ModalManager({
    viewUrl: '/InvoiceModal'
});

$("#OpenModal").click(function () {
    InvoiceModal.open();
});

InvoiceModal.onOpen(function () {
    console.log('opened the modal...');
});

$(function () {
    dataTable;
    
})

var responseCallback = function (result) {

    // your custom code.

    return {
        recordsTotal: result.totalCount,
        recordsFiltered: result.totalCount,
        data: result.items
    };
};
var dataTable = $('#InvoiceTable').DataTable(
    abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        searching: true,
        ajax: abp.libs.datatables.createAjax(invoiceApp.services.invoiceServices.getListAsnyc),
        columnDefs: [
            {
                title: "Action",
                rowAction: {
                    items:
                        [
                            {
                                text: "Edit",
                                action: function (data) {
                                    console.log("edit");
                                }
                            }
                        ]
                }
            },
            {
                title: "Date",
                data: "date",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, {
                            locale: abp.localization.currentCulture.name
                        }).toLocaleString();
                }
            },
            {
                title: "Refundable",
                data: "refundable"
            },
            {
                title: "Type",
                data: "type"
            },
            {
                title: "Invoice No.",
                data: "id"
            }
            
            
            
        ]
    })
);
