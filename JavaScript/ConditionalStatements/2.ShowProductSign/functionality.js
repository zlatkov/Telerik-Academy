function showProductSign() {
    var firstNumber = document.getElementById("first-number-input").value;
    var secondNumber = document.getElementById("second-number-input").value;
    var thirdNumber = document.getElementById("third-number-input").value;

    if (isValidNumber(firstNumber) && isValidNumber(secondNumber) && isValidNumber(thirdNumber)) {
        firstNumber = parseFloat(firstNumber);
        secondNumber = parseFloat(secondNumber);
        thirdNumber = parseFloat(thirdNumber);

        var countNegative = 0;
        if (firstNumber < 0) {
            countNegative++;
        }
        if (secondNumber < 0) {
            countNegative++;
        }
        if (thirdNumber < 0) {
            countNegative++;
        }

        if (countNegative % 2 === 0) {
            console.log("The sign of the product is: +");
        }
        else {
            console.log("Ths sign of the product is: -");
        }
    }
    else {
        console.log("Invalid input.");
    }
}

function isValidNumber(number) {
    if (isFinite(number)) {
        return true;
    }
    else {
        return false;
    }
}