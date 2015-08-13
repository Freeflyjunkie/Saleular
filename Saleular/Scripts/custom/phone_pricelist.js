$(document).ready(function () {

    SetTooltip($('.pointer-tooltip'));  

    // wire businessType dropdown
    WireSelectButton($('#businessTypeDropdown li a'), $('#businessTypeSelection'), $('#businessAreaHidden'));
});

function WireSelectButton(dropdownElements, selectControl, hiddenControl) {
    dropdownElements.on('click', function (e) {
        e.preventDefault();

        // set selection text
        var selection = $(this).text();        
        selectControl.text(selection);
        hiddenControl.val(selection);        
    });
}

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}
