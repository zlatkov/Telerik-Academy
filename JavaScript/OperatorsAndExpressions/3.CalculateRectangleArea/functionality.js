function calculateArea() {
    var width = document.getElementById("input-width").value;
    var height = document.getElementById("input-height").value;

    if (validNumber(width) && validNumber(height)) {
        var area = parseFloat(width) * parseFloat(height);
        console.log("Tha area of the rectangle is: " + area);
    }
    else {
        console.log("Invalid numbers.");
    }
}

function validNumber(number) {
    if (isFinite(number)) {
        return true;
    }
    else {
        return false;
    }
}