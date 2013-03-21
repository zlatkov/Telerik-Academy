function compareCharArrays() {
    var firstArray = document.getElementById("first-char-array").value;
    var secondArray = document.getElementById("second-char-array").value;

    var minLength = Math.min(firstArray.length, secondArray.length), i;
    var differenceFound = false;

    for (i = 0; i < minLength; ++i) {
        if (firstArray[i] < secondArray[i]) {
            differenceFound = true;
            console.log("The first char array is lexicographically before the second char array");
        }
        else if (firstArray[i] > secondArray[i]) {
            differenceFound = true;
            console.log("The second char array is lexicographically before the first char array");
        }
    }

    if (!differenceFound) {
        if (firstArray.length < secondArray.length) {
            console.log("The first char array is lexicographically before the second char array");
        }
        else if (firstArray.length > secondArray.length) {
            console.log("The second char array is lexicographically before the first char array");
        }
        else {
            console.log("The arrays are equal");
        }
    }
}