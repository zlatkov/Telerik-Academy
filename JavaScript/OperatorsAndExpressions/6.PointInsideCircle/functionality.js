function pointInsideCircle() {
    var x = document.getElementById("number-x-input").value;
    var y = document.getElementById("number-y-input").value;

    if (isValidNumber(x) && isValidNumber(y)) {
        x = parseFloat(x);
        y = parseFloat(y);

        if (x * x + y * y <= 25) {
            console.log("The point is inside the circle.");
        }
        else {
            console.log("The point is outside the circle.");
        }
    }
    else {
        console.log("Invalid coordinates.");
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