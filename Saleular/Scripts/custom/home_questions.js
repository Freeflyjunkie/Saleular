$(document).ready(function () {
    SetTooltip($('#nameAddon'));
    SetTooltip($('#emailAddon'));
});

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}