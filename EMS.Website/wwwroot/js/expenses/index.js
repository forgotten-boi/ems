
$('#approvalModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var expense = button.data('expense-name') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this);
    modal.find('.modal-title').text('Do you want to approve or reject ' + expense + '?')
    modal.find('.modal-body input').val(expense);
    modal.find('.btnapprove').attr('data-id', button.data('expenseid'));
    modal.find('.btnreject').attr('data-id', button.data('expenseid'));

})

$('.btnapprove').click(function () {
    var expenseId = $(this).last().attr("data-id");
    var status = true;
    Approval(expenseId, status);
});
$('.btnreject').click(function () {
    var expenseId = $(this).last().attr("data-id");
    var status = false;
    Approval(expenseId, status);
});

function Approval(id, status) {
    $.ajax({
        url: '/Expenses/Approval?id=' + id + '&status=' + status + '&comment=' + $("#message-text").val() + '',
        type: "GET",
        dataType: "JSON",
        success: function (data) {
            console.log(data);
            $('#approvalModal').hide();
            alert("Reciept has been approved!");
            location.reload(true);
        }
    });

}
function DeleteExpenses(travelId) {
    if (confirm("Are you sure you want to delete?")) {
        $.ajax({
            url: '/Expenses/Delete?id=' + travelId + '',
            type: "GET",
            dataType: "JSON",
            success: function (data) {
                console.log(data);

                alert("The reciept is Deleted!");
                location.reload(true);
            }
        });
    }
}
