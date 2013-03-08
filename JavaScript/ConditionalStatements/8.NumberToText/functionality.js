function convertToText() {
    var number = document.getElementById("integer-input").value;

    if (isValidInteger(number)) {
        number = parseInt(number, 10);

        if (number >= 0 && number <= 999) {

            var tens =
            [
                "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            ];

            var toNineteen =
            [
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            ];

            var firstDigit = parseInt(number / 100, 10);
            var secondDigit = parseInt((number / 10) % 10, 10);
            var thirdDigit = parseInt(number % 10, 10);

            var result = "";

            if (number >= 100) {
                result = toNineteen[firstDigit] + " hundred";
                if (secondDigit <= 1 && (secondDigit * 10 + thirdDigit > 0)) {
                    result += " and " + toNineteen[secondDigit * 10 + thirdDigit];
                }
                else if (secondDigit > 1 && thirdDigit == 0) {
                    result += " and " + tens[secondDigit - 2];
                }
                else if (secondDigit > 1 && thirdDigit > 0) {
                    result += " " + tens[secondDigit - 2] + " " + toNineteen[thirdDigit];
                }
            }
            else 
            {
                if (secondDigit <= 1) {
                    result = toNineteen[secondDigit * 10 + thirdDigit];
                }
                else {
                    result = tens[secondDigit - 2];
                    if (thirdDigit != 0) {
                        result += " " + toNineteen[thirdDigit];
                    }
                }
            }
            console.log(result);

        }
        else {
            console.log("The entered number must be in the range [0,999]");
        }
    }
    else {
        console.log("Invalid input.");
    }
}

function isValidInteger(number) {
    if (isFinite(number) && parseFloat(number) === parseInt(number, 10)) {
        return true;
    }
    else {
        return false;
    }
}