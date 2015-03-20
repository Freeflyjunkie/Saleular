$(document).ready(function () {

    SetTooltip($('.pointer-tooltip'));

    // wire Model dropdown
    WireSelectButton($('#modelDropdown li a'), $('#modelSelection'));

    // hide selection text
    var buttons = $('.hide-on-load');
    for (var i = 0; i < buttons.length; i++) {
        $(buttons[i]).hide();
    }

    if (window.location.search != '') {        
        var modelQs = window.location.href.split("?").slice(1).join("?");
        var model = modelQs.split('=');        
        LoadMenusWithModel(model[1]);
    }
});

function WireSelectButton(dropdownElements, selectControl) {
    dropdownElements.on('click', function (e) {
        e.preventDefault();

        // set selection text
        var selection = $(this).text();
        selectControl.text(selection);

        // is this the model dropdown?
        if ($(selectControl).attr('id') == 'modelSelection') {
            // create json for POST
            var selectedgadget = {
                SelectedType: 'iPhone',
                SelectedModel: $('#modelSelection').text(),
                SelectedCarrier: $('#carrierSelection').text(),
                SelectedCapacity: $('#capacitySelection').text(),
                SelectedCondition: $('#conditionSelection').text()
            }

            GetSelectedGadgetViewModel(selectedgadget);
        }
    });
}

function LoadMenusWithModel(model) {

    // create json for POST
    var selectedgadget = {
        SelectedType: 'iPhone',
        SelectedModel: model,
        SelectedCarrier: '',
        SelectedCapacity: '',
        SelectedCondition: ''
    }

    GetSelectedGadgetViewModel(selectedgadget);
}

function GetSelectedGadgetViewModel(selectedgadget) {

    $.ajax({
        type: "POST",
        url: '/Phone/GetSelectedGadgetViewModel',
        data: selectedgadget,
        dataType: 'json',
        success: function (data, status, xhr) {

            // Show menus
            var buttons = $('.hide-on-load');
            buttons.show();

            // Reset selection text based type and model
            $('#modelSelection').text(data.SelectedModel);
            $('#carrierSelection').text(data.SelectedCarrier);
            $('#capacitySelection').text(data.SelectedCapacity);
            $('#conditionSelection').text(data.SelectedCondition);

            // Populate dropdowns based on Type selection text
            PopulatePhoneDropdowns(data.Models, $('#modelDropdown'));
            PopulatePhoneDropdowns(data.Carriers, $('#carrierDropdown'));
            PopulatePhoneDropdowns(data.Capacities, $('#capacityDropdown'));
            PopulatePhoneDropdowns(data.Conditions, $('#conditionDropdown'));

            // Wire dropdowns
            WireSelectButton($('#modelDropdown li a'), $('#modelSelection'));
            WireSelectButton($('#carrierDropdown li a'), $('#carrierSelection'));
            WireSelectButton($('#capacityDropdown li a'), $('#capacitySelection'));
            WireSelectButton($('#conditionDropdown li a'), $('#conditionSelection'));
        },
        error: function (xhr, status, error) {
            alert(status);
            alert(xhr.status);
            alert(xhr.responseJSON);
            alert(xhr.responseText);
            alert(error);
        }
    });
}

function PopulatePhoneDropdowns(data, dropdown) {
    var html = '';
    for (var i = 0; i < data.length; i++) {
        var liBegin = "<li><a href='#'>";
        var liText = data[i];
        var liEnd = "</a></li>";
        html = html + liBegin + liText + liEnd;
    }
    $(dropdown).html(html);
}

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}
