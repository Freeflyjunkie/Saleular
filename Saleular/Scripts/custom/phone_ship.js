$(document).ready(function () {

    SetTooltip($('#nameAddon'));
    SetTooltip($('#emailAddon'));
    SetTooltip($('#addressAddon'));
    SetTooltip($('#cityAddon'));
    SetTooltip($('#stateAddon'));
    SetTooltip($('#zipAddon'));

    $('input[name=zip]').on('blur', function () {
        var url = 'http://zip.elevenbasetwo.com/v2/US/' + $(this).val();
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'json',
            success: function (data, status, xhr) {
                $('input[name=state]').val(data["state"]);
                $('input[name=city]').val(data["city"]);
                $("#shipForm").submit();
            }
        });
    });


    $.validator.addMethod("NumbersOnly", function (value, element) {
        return this.optional(element) || /^[0-9\-\+]+$/i.test(value);
    }, "Phone must contain only numbers, + and -.");


    $("#shipForm").validate({
        rules: {
            zip: "required NumbersOnly",
            name: {
                required: true,
                minlength: 2
            },
            address: {
                required: true,
            },
            city: {
                required: true,
            },
            state: {
                required: true,
                minlength: 2
            },
            email: {
                required: true,
                email: true
            }
        },
        messages: {
            name: {
                required: "Your name is required",
                minlength: "Your name must be at least {0} characters"
            },
            address: {
                required: "Your address is required"
            },
            zip: {
                required: "Your zip is required"
            },
            city: {
                required: "Your city is required"
            },
            state: {
                required: "Your state is required",
                minlength: "Your state must be at least {0} characters"
            },
            email: {
                required: "Your email is required"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent("div").parent("div").parent("div").children('.validation-error').html(error.html());
        },
        success: function (label) {
            //$(label).parent("div").parent("div").parent("div").children('.validation-error').html('ok');
        },
        highlight: function (element, errorClass, validClass) {
            var field = $(element.form).find("input[name=" + element.id + "]");
            field.css('border', '1px solid red');
        },
        unhighlight: function (element, errorClass, validClass) {
            var field = $(element.form).find("input[name=" + element.id + "]");
            field.css('border', 'none');
        }
    });
});

function SetTooltip(addon) {
    addon.tooltip();
    addon.css('cursor', 'pointer');
}