function printMaxAndMin() {
    var sequence = [432, 32, 1, 43929, -432, 34939439, -493292, 4];

    if (sequence.length > 0) {
        var minElementIndex = 0, maxElementIndex = 0, i;
        for (i = 1; i < sequence.length; ++i) {
            if (sequence[i] < sequence[minElementIndex]) {
                minElementIndex = i;
            }
            if (sequence[i] > sequence[maxElementIndex]) {
                maxElementIndex = i;
            }
        }

        console.log("The sequenec is: " + sequence);
        console.log("Min element: " + sequence[minElementIndex] + " at index " + minElementIndex);
        console.log("Max element: " + sequence[maxElementIndex] + " at index " + maxElementIndex);
        
    }
    else {
        console.log("The sequence is empty.");
    }
}
