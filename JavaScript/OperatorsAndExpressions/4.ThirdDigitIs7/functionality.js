function thirdDigitIs7() {
    var number = document.getElementById("number-input").value;
    if (isValidInteger(number)) {
        if (number.length < 3) {
            console.log(number + " has less than 3 digits.");
        }
        else {
            if (number[number.length - 3] == "7") {
                console.log("The third digit is 7.");
            }
            else {
                console.log("The third digit is not 7.");
            }
        }
    }
    else {
        console.log("Invalid number.");
    }
}

function isValidInteger(number) {
    if (isFinite(number) && parseFloat(number) == parseInt(number)) {
        return true;
    }
    else {
        return false;
    }
}