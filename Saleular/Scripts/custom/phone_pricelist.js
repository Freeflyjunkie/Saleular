$(document).ready(function () {

    SetTooltip($('.pointer-tooltip'));  

    // wire businessType dropdown
    WireSelectButton($('#businessTypeDropdown li a'), $('#businessTypeSelection'));
});

function WireSelectButton(dropdownElements, selectControl) {
    dropdownElements.on('click', function (e) {
        e.preventDefault();

        // set selection text
        var selection = $(this).text();        
        selectControl.text(selection);

        var areaSelection = $('#businessAreaInput');
        areaSelection.val(selection);
    });
}

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}
