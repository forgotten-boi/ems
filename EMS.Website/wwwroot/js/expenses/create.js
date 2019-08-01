$(document).ready(function () {

    if ($('#isFinance').val() !== "" && $('#isFinance').val() === 'True') {
        $("#form input, #form select").prop("readonly", true);
        $("#form input").prop("disabled", true);
    }

    $('#ExpensesList').hide();
    $('#btnExpenses').click(function () {
        $('#ExpensesList').show();
        $("#addDetail").hide();
    });

    $('#Details').change(function () {
        var details = $("#Details option:selected").text();
        if (details === 'Misc. Expenses (please explain below)' || details === 'Entertainment F&B (please explain below)') {
            $("#addDetail").show();
        }
    });

});
(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);

$(document).ready(function () {

    var mscList = [];

    $("#btnAdd").on('click', function () {

        var date = $('#Date').val();
        var details = $("#Details option:selected").text();
        var price = $("#Price").val();
        
        if (date === "" || details === null || price === "") {
            alert('date, details and price cannot be null');
        }
        else {
            populateMscList();
            var subRow = '';
            if (mscList && mscList.length) {
                subRow += `
                         <table class="mscList">
                             <thead>
                                <tr>
                                    <th>Detail</th>
                                    <th>Date</th>
                                    <th>Amount</th>
                                 </tr>
                              </thead>
                          <tbody>
                            `;
                $.each(mscList, function (index, value) {
                    subRow += `<tr>
                                   <td class="miscDetails">${value.Date}</td>
                                   <td class="miscDate">${value.Comment}</td>
                                   <td class="miscExpenses">${value.Price}</td>
                               </tr>`;
                });
                subRow += `
                        </tbody>
                                    </table>
                        `
                mscList = [];
            }
            var row = `<tr class='expenserow'>
                           <td class="date">${date}</td>
                           <td class="details">${details}
                           </td>
                           <td>${subRow}</td>
                           <td class="expenses">${price}</td>

                           <td>
                                <a class="btnDelete" title="Delete">
                                    <i class="fas fa-trash"></i>
                                </a>
                            </td>
                       </tr>`;

            $('#Items').append(row);
            calculateSum();
        }
      
    });

    var counter = 0;


    $("#btnMisc").on('click', function () {


        var row = ` <li >
                        <div class="row">
                            <input type="date" placeholder="Date" class="form-control col-md-4 miscDate" name="mscDate-${counter}">
                            <input type="text" placeholder="Details" class="form-control col-md-4 miscDetails" name="Details-${counter}">
                            <input type="number" placeholder="Amount" class="form-control col-md-2 miscExpenses" name="Expenses-${counter}" />
                            
                            <a  class="btn btn-primary btnMscDel" style='float:right'>
                                <i class="fa fa-trash"></i>
                            </a>
                         </div>
                     </li>`;

        $('#mscItem').append(row);
        calculateMscGrandTotal();


        counter++;


    });




    function populateMscList() {
        for (var newCounter = 0; newCounter < counter; newCounter++) {



            var mscDate = $('[name=mscDate-' + newCounter + ']').val();
            var mscDetails = $('[name=Details-' + newCounter + ']').val();
            var mscExpenses = $('[name=Expenses-' + newCounter + ']').val();
            if (mscDate && mscDetails && mscExpenses ) {
                var msc = {
                    Date: mscDate,
                    Comment: mscDetails,
                    Price: mscExpenses
                };
                mscList.push(msc);
                console.log(mscList);
            }

        }
    }

    $("ul.order-list").on("click", ".btnMscDel", function (event) {
        $(this).closest("li").remove();
        counter -= 1;
    });

    $('ul.order-list').on("change", ".miscExpenses", function () {
        console.log($('.miscExpenses').val());
        calculateMscGrandTotal();
    });
});

function calculateMscRow(row) {
    var price = +row.find('input[name^="Expenses"]').val();

}

function calculateMscGrandTotal() {
    var grandTotal = 0;
    $("ul.order-list").find('input[name^="Expenses"]').each(function () {
        grandTotal += +$(this).val();
    });
    $("#Price").val(grandTotal.toFixed(2));
}


function calculateSum() {
    var sum = 0;
    // iterate through each td based on class and add the values
    $(".expenses").each(function () {

        var value = $(this).text();
        // add only if the value is number
        if (!isNaN(value) && value.length !== 0) {
            sum += parseFloat(value);
        }
    });

    $('#TotalExpenses').val(sum);

};

$('#Items').on('click', '.btnDelete', function () {
    $(this).parents('tr').remove();
    calculateSum();
});

$(document).ready(function () {



    // $("#btnSubmit").click(function (e) {
    $("#form").submit(function (e) {


        var formData = $(this).serializeFormJSON();
        console.log(formData);
        e.preventDefault();

        var object = formData;

        var list = [];


        console.log(list);

        object.TravelExpensesDtos = [];
        $('#Items tr.expenserow').each(function (index, ele) {
            var orderItem = {

                details: $('.details', this).text(),
                date: $('.date', this).text(),
                expenses: parseFloat($('.expenses', this).text())
            };
            orderItem.MiscExpensesDtos = [];
             newCounter = 0;
            $(this).find('table.mscList tr').each(function (i, value) {
                console.log($('.details', this).text());
               
                var mscDate = $('[name=mscDate-' + newCounter + ']').val();
                var mscDetails = $('[name=Details-' + newCounter + ']').val();
                var mscExpenses = $('[name=Expenses-' + newCounter + ']').val();
                console.log(mscDate);
                if (mscDate && mscDetails && mscExpenses ) 
                    {
                        var msc = {
                            Date: mscDate,
                            Comment: mscDetails,
                            Price: mscExpenses
                        };
                        newCounter++;
                        orderItem.MiscExpensesDtos.push(msc);
                    }
            });
            object.TravelExpensesDtos.push(orderItem);
        });



        console.log(object);

        var input = document.getElementById('RecieptFile');
        var files = input.files;
        var fileData = new FormData();

        for (var i = 0; i !== files.length; i++) {
            fileData.append("files", files[i]);
        }
        console.log(fileData);
        $.ajax(
            {
                url: "/Expenses/FileUpload",
                data: fileData,
                processData: false,
                contentType: false,
                type: "POST",
                success: function (data) {

                    recieptPath = data;
                    object.RecieptDoc = data;
                    $.ajax({
                        type: 'POST',
                        url: '/Expenses/Create',
                        datatype: "Json",
                        data: object,
                        //contentType: 'application/json',
                        success: function (data) {
                            console.log(data);
                            if (data !== null) {
                                alert(data.message);
                            }
                            window.location.href = '/Expenses/Index';

                        },
                        error: function (error) {
                            console.log(error);
                        }
                    });
                }
            }
        );

    });

});
