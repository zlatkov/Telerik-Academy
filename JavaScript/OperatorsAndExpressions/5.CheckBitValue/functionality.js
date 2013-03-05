function checkBitValue() {
    var number = document.getElementById("number-input").value;
    if (isValidInteger(number)) { 
        number = parseInt(number);
        console.log("The bit at position 3 has value: " + ((number >> 3) & 1).toString());
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