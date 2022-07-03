
var InvoiceModal = new abp.ModalManager({
    viewUrl: '/InvoiceModal'
});

$("#OpenModal").click(function () {
    InvoiceModal.open();
});

InvoiceModal.onOpen(function () {
    console.log('opened the modal...');
});
/*var { request, data, settings } = abp.libs.datatables.createAjax(invoiceApp.services.invoiceServices.getListAsnyc());*/
var request = null;
var data;
async function fetchData() {
     request = await abp.ajax({
        type: 'GET',
         url: "api/app/invoice-services/asnyc"
    }).then(function (result) {
        console.log(result);
        data = result;
    });
}

$(async function () {
    await fetchData();
    await console.log(data);
    var datatable = $('#InvoiceTable').DataTable(abp.libs.datatables.normalizeConfiguration({
       searching: true,
        paging: true,
        ajax: {
            url: "api/app/invoice-services/asnyc",
            dataSrc: ""
        } ,
        columnDefs: [
            
            {
                title: 'Invoice No.',
                data: "id"
            },
            {
                title: "Date",
                data: "date",
                dataFormat: 'datetime'
            },
            {
                title: 'Type',
                data: "type"
            },
            {
                title: 'Refundable',
                data: "refundable"
            },
            {
                title: 'Actions',
                rowAction: {
                    items:
                        [
                            {
                                text: 'Edit',
                                action: function (data) {
                                    InvoiceModal.open({
                                        invoiceId: data.record.id
                                    });
                                    InvoiceModal.onClose(function () {
                                        datatable.ajax.reload();
                                    });
                                    
                                }
                            },
                            {
                                text: 'Delete',
                                action: function (data) {
                                    InvoiceModal.open();
                                }
                            }
                        ]
                }
            },
        ]
    }));
});