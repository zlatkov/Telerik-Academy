function solveQuadraticEquation() {
    var a = document.getElementById("first-number-input").value;
    var b = document.getElementById("second-number-input").value;
    var c = document.getElementById("third-number-input").value;

    if (isValidNumber(a) && isValidNumber(b) && isValidNumber(c)) {
        a = parseFloat(a);
        b = parseFloat(b);
        c = parseFloat(c);

        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0) {
            console.log("There are 0 real roots.");
        }
        else if (discriminant === 0) {
            console.log("There is 1 real root: " + -b / (2 * a));
        }
        else {
            var x1 = (-b - Math.sqrt(discriminant)) / (2 * a);
            var x2 = (-b + Math.sqrt(discriminant)) / (2 * a);

            console.log("There are 2 real roots: " + x1 + " and " + x2);
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