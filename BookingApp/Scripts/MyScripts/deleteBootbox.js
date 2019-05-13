$(document).ready(function () {
    $(".js-cancel-gig").click(function (e) {
        var link = $(e.target);

        bootbox.dialog({
            title: 'Confirm Deletion',
            message: "Are You sure you want to delete this Property?",
            buttons: {
                no: {
                    label: "No",
                    className: 'btn-default',
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Yes",
                    className: 'btn-danger',
                    callback: function () {
                        $.ajax({
                            url: "/Property/Delete/" + link.attr("data-gig-id"),
                            method: "DELETE"
                        })
                            .done(function () {
                                document.location.reload(true);
                                link.parents("li").fadeOut(function () {
                                    $(this).remove();


                                });
                            })
                            .fail(function () {
                                alert("Something Failed");
                            });
                    }
                }
            }
        });
    });

});