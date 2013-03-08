function examineIntegers() {
    var firstNumber = document.getElementById("first-integer-input").value;
    var secondNumber = document.getElementById("second-integer-input").value;

    if (isInteger(firstNumber) && isInteger(secondNumber)) {
        firstNumber = parseInt(firstNumber, 10);
        secondNumber = parseFloat(secondNumber, 10);

        if (firstNumber > secondNumber) {
            var tmp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tmp;

            console.log("Values have been swapped.");
        }
        else {
            console.log("Values were not swapped.");
        }

        console.log("First integer value: " + firstNumber);
        console.log("Second integer value: " + secondNumber);
    }
    else {
        console.log("Invalid input.");
    }
}

function isInteger(number) {
    if (isFinite(number) && parseFloat(number, 10) === parseInt(number, 10)) {
        return true;
    }
    else {
        return false;
    }
}