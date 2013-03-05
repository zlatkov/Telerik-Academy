function calculateArea() {
    var sideA = document.getElementById("number-a-input").value;
    var sideB = document.getElementById("number-b-input").value;
    var height = document.getElementById("number-h-input").value;

    if (isValidNumber(sideA) && isValidNumber(sideB) && isValidNumber(height)) {
        sideA = parseFloat(sideA);
        sideB = parseFloat(sideB);
        height = parseFloat(height);

        if (sideA < 0 || sideB < 0 || height < 0) {
            console.log("One or more sides of the trapezoid are negative.");
        }
        else {
            var area = ((sideA + sideB) / 2.0) * height;
            console.log("The side of the trapezoid is: " + area);
        }
    }
    else {
        console.log("Invalid numbers.");
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