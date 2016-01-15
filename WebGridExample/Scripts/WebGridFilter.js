var options = [];

$(function() {

    var $grid = $("#grid");

    // Force the 'select all' checkbox on/off
    function updateSelectAll(anchor) {
        var parent = $(anchor).closest(".dropdown-menu");
        // Are any checkboxes checked?
        var isAll = $(".filterbox:not(:checked)", parent).length === 0;
        setTimeout(function () {
            $("a[data-value='all'] :checkbox", parent).prop('checked', isAll);
        }, 0);
    }

    // 'Select All' [Click]
    $("a[data-value='all']").on("click", function () {
        var $parent = $(this).closest(".dropdown-menu"),
            isChecked = $(":checkbox", this).is(":checked");

        $(":checkbox", this).prop("checked", !isChecked);
        $(".filterbox", $parent).prop("checked", !isChecked);
        $("td:nth-child(1)", $grid).closest("tr").toggle(!isChecked);
    });

    // Filter Checkbox
    $('.dropdown-menu a', $grid).on('click', function (event) {

        var self = this;

        var $target = $(event.currentTarget),
            id = $target.attr('data-value'),
            value = $target.text().trim(),
            $inp = $target.find('input'),
            idx,
            $row = $("td:contains('"+value+"')", $grid)
                .closest("tr");

        if ((idx = options.indexOf(id)) > -1) {
            options.splice(idx, 1);
            $row.show();
            setTimeout(function() {
                $inp.prop('checked', true);
                updateSelectAll(self);
            }, 0);
        } else {
            options.push(id);
            $row.hide();
            setTimeout(function() {
                $inp.prop('checked', false);
                updateSelectAll(self);
            }, 0);
        }

        $(event.target).blur();

        return false;
    });
});
