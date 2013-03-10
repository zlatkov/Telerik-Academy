function displaySmallestAndLargestProperties() {
    displaySmallestAndLargest(document);
    displaySmallestAndLargest(window);
    displaySmallestAndLargest(navigator);
}

function displaySmallestAndLargest(obj) {
    var smallestProperty, largestProperty, propertiesInitialized = false;

    for (var property in obj) {
        if (obj[property] === "" || obj[property] === null) {
            continue;
        }
        if (!propertiesInitialized) {
            smallestProperty = obj[property];
            largestProperty = obj[property];

            propertiesInitialized = true;
        }
        else {
            if (obj[property] < smallestProperty) {
                smallestProperty = obj[property];
            }
            if (obj[property] > largestProperty) {
                largestProperty = obj[property];
            }
        }
    }

    console.log("Smallest property in " + obj + " is: " + smallestProperty);
    console.log("Largest property in " + obj + " is: " + largestProperty);
}