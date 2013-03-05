function divisibleBy5And7() {
    var number = document.getElementById("number-input").value;
    if (isValidNumber(number)) {
        number = parseInt(number);
        if (number % 5 == 0 && number % 7 == 0) {
            console.log(number + " is divisible by 5 and 7.");
        }
        else {
            console.log(number + " is not divisible by 5 and 7.");
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