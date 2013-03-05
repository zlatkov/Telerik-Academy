function determinePosition() {
    var x = document.getElementById("number-x-input").value;
    var y = document.getElementById("number-y-input").value;

    if (isValidNumber(x) && isValidNumber(y)) {
        x = parseFloat(x);
        y = parseFloat(y);
        if (insideCircle(x, y) && !insideRectangle(x, y)) {
            console.log("The point is inside the circle and outside the rectangle.");
        }
        else {
            console.log("The point is outside the circle or inside the rectangle.");
        }
    }
    else {
        console.log("Invalid coordinates.");
    }
}

function insideCircle(x, y) {
    if (Math.pow(x - 1, 2) + Math.pow(y - 1, 2) <= 9) {
        return true;
    }
    else {
        return false;
    }
}

function insideRectangle(x, y) {
    if (x >= -1 && x <= 5 && y <= 1 && y >= -1) {
        return true;
    }
    else {
        return false;
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