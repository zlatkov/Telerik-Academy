var numbers = new Array(20), i;

for (i = 0; i < 20; ++i) {
    numbers[i] = i * 5;
}

for (i = 0; i < 20; ++i) {
    console.log("The value at index " + i + " is " + numbers[i]);
}