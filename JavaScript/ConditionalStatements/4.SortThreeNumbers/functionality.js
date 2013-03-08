function sortNumbersDescending() {
    var nums =
        [
            document.getElementById("first-number-input").value,
            document.getElementById("second-number-input").value,
            document.getElementById("third-number-input").value
        ];

    if (isValidNumber(nums[0]) && isValidNumber(nums[1]) && isValidNumber(nums[2])) {
        for (var i = 0; i < 3; ++i) {
            nums[i] = parseFloat(nums[i]);
        }

        if (nums[0] > nums[1] && nums[0] > nums[2]) {
            if (nums[2] > nums[1]) {
                nums = [nums[0], nums[2], nums[1]];
            }
        }
        else if (nums[1] > nums[0] && nums[1] > nums[2]) {
            if (nums[0] > nums[2]) {
                nums = [nums[1], nums[0], nums[2]];
            }
            else {
                nums = [nums[1], nums[2], nums[0]];
            }
        }
        else if (nums[2] > nums[0] && nums[2] > nums[1]) {
            if (nums[0] > nums[1]) {
                nums = [nums[2], nums[0], nums[1]];
            }
            else {
                nums = [nums[2], nums[1], nums[0]];
            }
        }

        console.log("The sorter numbers in descending order: " + nums[0] + " " + nums[1] + " " + nums[2]);
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