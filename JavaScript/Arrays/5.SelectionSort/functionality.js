function sortSequence() {
    var input = document.getElementById("elements-input").value;
    
    if (input.length > 0) {
        var elements = input.split(" ");
        var i, j, smallestIndex, tmp;

        for (i = 0; i < elements.length; ++i) {
            elements[i] = parseInt(elements[i], 10);
        }

        for (i = 0; i < elements.length; ++i) {
            smallestIndex = i;
            for (j = i + 1; j < elements.length; ++j) {
                if (elements[smallestIndex] > elements[j]) {
                    smallestIndex = j;
                }
            }
            tmp = elements[i];
            elements[i] = elements[smallestIndex];
            elements[smallestIndex] = tmp;
        }

        for (i = 0; i < elements.length; ++i) {
            console.log(elements[i]);
        }
    }
    else {
        console.log("The sequence is empty.");
    }
}