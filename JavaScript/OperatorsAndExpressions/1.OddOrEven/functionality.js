function oddOrEven() {
    var number = document.getElementById("number-input").value;

    if (isValidNumber(number)) {
        number = parseInt(number);
        if (number % 2 == 0) {
            console.log("The number is even.");
        }
        else {
            console.log("The number is odd.");
        }
    }
    else {
        console.log("Invalid number.");
    }
}

function isValidNumber(number) {
    if (parseInt(number) == parseFloat(number) && isFinite(number)) {
        return true;
    }
    else {
        return false;
    }
}