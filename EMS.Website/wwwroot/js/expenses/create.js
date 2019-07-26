$(document).ready(function () {

    if ($('#isFinance').val() !== "" && $('#isFinance').val() === 'True') {
        $("#form input, #form select").prop("readonly", true);
        $("#form input").prop("disabled", true);
    }
});


$("#btnAdd").on('click', function () {
    var date = $('#Date').val();
    var details = $("#Details option:selected").text();
    var price = $("#Price").val();


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

    var recieptPath = '';
    function uploadFiles(inputId) {
        var input = document.getElementById(inputId);
        var files = input.files;
        var formData = new FormData();

        for (var i = 0; i != files.length; i++) {
            formData.append("files", files[i]);
        }
        console.log(formData);
        $.ajax(
            {
                url: "/Expenses/FileUpload",
                data: formData,
                processData: false,
                contentType: false,
                type: "POST",
                success: function (data) {
                    alert("Files Uploaded!");
                    console.log(data);
                    recieptPath = data;
                }
            }
        );
    }

    $("#btnSubmit").click(function (e) {
        //$("#form").submit(function (e) {
        debugger;


        uploadFiles("RecieptFile");
        var formData = $(this).serializeFormJSON();
            console.log(formData);
            e.preventDefault();



        var list = [];
       

        console.log(list);
        var object = {
            employeeFName: $('#EmployeeFName').val(),
            employeeLName: $('#EmployeeLName').val(),
            destination: $('#Destination').val(),
            purpose: $('#Purpose').val(),
            recieptDoc: recieptPath,
            iBAN: $('#IBAN').val(),
            bankName: $('#BankName').val(),
            department: $('#Department').val(),
            currency: $('#Currency').val(),
            startDate: $('#StartDate').val(),
            endDate: $('#EndDate').val(),
            startTime: $('#StartTime').val(),
            endTime: $('#EndTime').val(),
            travelExpenseDto: list

        };

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

        $.ajax({
            type: 'POST',
            url: '/Expenses/Create',
            datatype: "Json",
            data: object,
            //contentType: 'application/json',
            success: function () {
                //alert('Successfully saved');
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

});
