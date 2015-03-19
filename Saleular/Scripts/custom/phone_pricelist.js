$(document).ready(function () {

    SetTooltip($('#businessNameAddon'));
    SetTooltip($('#nameAddon'));
    SetTooltip($('#emailAddon'));
    SetTooltip($('#phoneAddon'));
    SetTooltip($('#addressAddon'));
    SetTooltip($('#taxIdAddon'));
    SetTooltip($('#businessAreaAddon'));

    //$('#guarenteed-text-span').hide();
    //$('#navmenu .nav').hide();

    // wire Model dropdown
    WireSelectButton($('#businessAreaDropDown li a'), $('#businessAreaSelection'));
});

function WireSelectButton(dropdownElements, selectControl) {
    dropdownElements.on('click', function (e) {
        e.preventDefault();

        // set selection text
        var selection = $(this).text();
        selectControl.val(selection);
    });
}

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}
