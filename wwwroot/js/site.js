function reservationSendData(methodPath) {
    $.post(methodPath, {}).done(function (success) {
        if (success) {
            window.location.reload();
        }
        else {
            alert("Failed to complete your " + (isReserve)?"reservation":"cancelation");
        }
    })
}

function partnerFinder(methodPath) {
    $.post(methodPath, {}).done(function (success) {
        if (success) {
            window.location.reload();
        }
        else {
            alert("Failed to complete your PartnerFinder request. Please try again");
        }
    })
}

function CheckAptNumberExist(methodPath) {
    $.post(methodPath, {}).done(function (data) {
        return data;
    })
}
