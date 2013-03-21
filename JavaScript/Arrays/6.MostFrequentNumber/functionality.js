function mostFrequentNumber() {
    var input = document.getElementById("elements-input").value;

    if (input.length > 0) {
        var elements = input.split(" ");
        var i, j, mostFrequentIndex = 0, mostFrequentCount = 0, tmpCount = 0;

        for (i = 0; i < elements.length; ++i) {
            elements[i] = parseInt(elements[i], 10);
        }

        for (i = 0; i < elements.length; ++i) {
            tmpCount = 0;
            for (j = 0; j < elements.length; ++j) {
                if (elements[i] === elements[j]) {
                    tmpCount++;
                }
            }
            if (tmpCount > mostFrequentCount) {
                mostFrequentCount = tmpCount;
                mostFrequentIndex = i;
            }
        }

        console.log("The most frequent number is " + elements[mostFrequentIndex] + " with frequency " + mostFrequentCount);
    }
    else {
        console.log("The sequence is empty.");
    }
}