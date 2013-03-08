function showBiggestInteger() {
    var firstInteger = document.getElementById("first-integer-input").value;
    var secondInteger = document.getElementById("second-integer-input").value;
    var thirdInteger = document.getElementById("third-integer-input").value;

    if (isValidInteger(firstInteger) && isValidInteger(secondInteger) && isValidInteger(thirdInteger)) {
        firstInteger = parseInt(firstInteger, 10);
        secondInteger = parseInt(secondInteger, 10);
        thirdInteger = parseInt(thirdInteger, 10);

        if (firstInteger > secondInteger) {
            if (firstInteger > thirdInteger) {
                console.log("The biggest integer is: " + firstInteger);
            }
            else {
                console.log("The biggest integer is: " + thirdInteger);
            }
        }
        else if (secondInteger > firstInteger) {
            if (secondInteger > thirdInteger) {
                console.log("The biggest integer is: " + secondInteger);
            }
            else {
                console.log("THe biggest integer is: " + thirdInteger);
            }
        }
        else if (thirdInteger > secondInteger) {
            if (thirdInteger > firstInteger) {
                console.log("The biggest integer is: " + thirdInteger);
            }
            else {
                console.log("The biggest integer is: " + firstInteger);
            }
        }
        else if (secondInteger > thirdInteger) {
            if (secondInteger > firstInteger) {
                console.log("The biggest integer is: " + secondInteger);
            }
            else {
                console.log("The biggest integer is: " + firstInteger);
            }
        }
        else if (firstInteger > thirdInteger) {
            if(firstInteger > secondInteger) {
                console.log("The biggest integer is: " + firstInteger);
            }
            else {
                console.log("The biggest integer is: " + secondInteger);
            }
        }
        else if (thirdInteger > secondInteger) {
            if (thirdInteger > firstInteger) {
                console.log("The biggest integer is: " + thirdInteger);
            }
            else {
                console.log("The biggest integer is: " + firstInteger);
            }
        }
        else {  //All numbers are equal.
            console.log("The biggest integer is: " + firstInteger);
        }
        
    }
    else {
        console.log("Invalid input");
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