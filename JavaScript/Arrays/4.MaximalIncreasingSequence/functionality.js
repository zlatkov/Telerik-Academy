function findSequence() {
    var input = document.getElementById("elements-input").value;

    if (input.length > 0) {
        var elements = input.split(" ");

        for (i = 0; i < elements.length; ++i) {
            elements[i] = parseInt(elements[i], 10);
        }

        var bestBeginIndex = 0, curBeginIndex = 0, maximalLength = 1, currentLength = 1, i;

        for (i = 0; i < elements.length - 1; ++i) {
            if (elements[i] < elements[i + 1]) {
                currentLength++;
            }
            else {
                currentLength = 1;
                curBeginIndex = i + 1;
            }
            if (currentLength > maximalLength) {
                maximalLength = currentLength;
                bestBeginIndex = curBeginIndex;
            }
        }

        for (i = bestBeginIndex; i < bestBeginIndex + maximalLength; ++i) {
            console.log("At positon: " + i + " with value: " + elements[i]);
        }
    }
    else {
        console.log("The sequence is empty");
    }
}