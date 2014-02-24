$(document).ready(function () {

    // wire Model dropdown
    WireSelectButton($('#typeDropdown li a'), $('#typeSelection'));

    // hide offer section
    $('#offerSection').hide();

    // hide selection text
    var buttons = $('.input-group');
    for (var i = 0; i < buttons.length; i++) {
        if (i > 0) {
            $(buttons[i]).hide();
        }
    }
});

function WireSelectButton(dropdownElements, selectControl) {
    dropdownElements.on('click', function (e) {

        e.preventDefault();

        // set selection text
        var selection = $(this).text();
        selectControl.text(selection);

        // is this the model dropdown?
        if ($(selectControl).attr('id') == 'typeSelection'
            || $(selectControl).attr('id') == 'modelSelection'
            || IsPriceReady()) {

            // create json for POST
            var selectedgadget = {
                SelectedType: $('#typeSelection').text(),
                SelectedModel: $('#modelSelection').text(),
                SelectedCarrier: $('#carrierSelection').text(),
                SelectedCapacity: $('#capacitySelection').text(),
                SelectedCondition: $('#conditionSelection').text()
            }

            // POST to RefreshSelection
            $.ajax({
                type: "POST",
                url: '/Phone/GetSelectedGadgetViewModel',
                data: selectedgadget,
                dataType: 'json',
                success: function (data, status, xhr) {
                    var buttons = $('.input-group');
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

                    // Show Offer and scroll to the bottom
                    if (IsPriceReady()) {
                        $('#offerSection').show();
                        $('#price h2').html('$' + data.Price + '.00');
                        $(document).scrollTop(1000);
                    }
                    else {
                        $('#offerSection').hide();
                    }
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

function IsPriceReady() {
    var selection = $('#typeSelection').text();

    if (selection.indexOf('Select', 0) == -1) {
        selection = $('#modelSelection').text();

        if (selection.indexOf('Select', 0) == -1) {
            selection = $('#carrierSelection').text();

            if (selection.indexOf('Select', 0) == -1) {
                selection = $('#capacitySelection').text();

                if (selection.indexOf('Select', 0) == -1) {
                    selection = $('#conditionSelection').text();

                    if (selection.indexOf('Select', 0) == -1) {
                        return true;
                    }
                }
            }
        }
    }

    return false;
}