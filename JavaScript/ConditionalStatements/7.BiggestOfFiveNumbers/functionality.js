function findBiggestNumber() {
    var nums = [];
    var i;

    for (i = 0; i < 5; ++i) {
        nums[i] = document.getElementById((i + 1) + "-number-input").value;
    }

    var validInput = true;
    for (i = 0; i < 5; ++i) {
        if (!isValidNumber(nums[i])) {
            validInput = false;
            break;
        }
    }
    
    if (validInput) {
        for (i = 0; i < 5; ++i) {
            nums[i] = parseFloat(nums[i]);
        }

        var biggestIndex = 0;
        for (i = 1; i < 5; ++i) {
            if (nums[i] > nums[biggestIndex]) {
                biggestIndex = i;
            }
        }

        console.log("The biggest number is: " + nums[biggestIndex]);
     
    }
    else {
        console.log("Invalid input.");
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