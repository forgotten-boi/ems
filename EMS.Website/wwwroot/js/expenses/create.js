$(document).ready(function () {

    if ($('#isFinance').val() !== "" && $('#isFinance').val() === 'True') {
        $("#form input, #form select").prop("readonly", true);
        $("#form input").prop("disabled", true);
    }

    $('#ExpensesList').hide();
    $('#btnExpenses').click(function () {
        $('#ExpensesList').show();
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


$("#btnAdd").on('click', function () {
    
    var date = $('#Date').val();
    var details = $("#Details option:selected").text();
    var price = $("#Price").val();

    if (date === "" || details === null || price === "")
    {
        alert('date, details and price cannot be null');
    }
    else {
        var row = `<tr>
                                    <td class="date">${date}</td>
                                    <td class="details">${details}</td>
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
    //clearValue();
});


function calculateSum() {
    var sum = 0;
    // iterate through each td based on class and add the values
    $(".price").each(function () {

        var value = $(this).text();
        // add only if the value is number
        if (!isNaN(value) && value.length !== 0) {
            sum += parseFloat(value);
        }
    });

    //$('#TotalAmount').val(sum);
    //var a = $('#TotalAmount').val();
    //var b = $('#GivenAmount').val();
    //$('#ChangeAmount').val(a - b);
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
        $('#Items tr').each(function (index, ele) {
            var orderItem = {

                details: $('.details', this).text(),
                date: $('.date', this).text(),
                expenses: parseFloat($('.expenses', this).text())
            };

            object.TravelExpensesDtos.push(orderItem);
        });



        console.log(object);
        var json = JSON.stringify(object);
        console.log(json);
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
