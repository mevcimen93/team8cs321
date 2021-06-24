function reservationSendData(methodPath, isReserve) {
    $.post(methodPath, {}).done(function (data) {
        if (data) {
            window.location.reload();
        }
        else {
            alert("Failed to complete your " + (isReserve)?"reservation":"cancelation");
        }
    })
}