function binarySearch() {
    var input = document.getElementById("elements-input").value;
    var searchNumber = document.getElementById("search-number-input").value;

    if (input.length > 0) {
        var elements = input.split(" ");
        var i, j, left = -1, right = input.length, middle, found = false;

        searchNumber = parseInt(searchNumber, 10);
        for (i = 0; i < elements.length; ++i) {
            elements[i] = parseInt(elements[i], 10);
        }

        while (left + 1 < right) {
            middle = parseInt((left + right) / 2, 10);
            if (elements[middle] === searchNumber) {
                found = true;
                break;
            }
            else if (elements[middle] < searchNumber) {
                left = middle;
            }
            else {
                right = middle;
            }
        }
        if (found) {
            console.log("The index of: " + searchNumber + " is " + middle);
        }
        else {
            console.log("The number is not found.");
        }
    }
    else {
        console.log("The sequence is empty.");
    }
}