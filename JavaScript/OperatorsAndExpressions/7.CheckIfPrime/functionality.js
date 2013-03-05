function checkIfPrime() {
    var number = document.getElementById("number-input").value;
    if (isValidInteger(number)) {
        number = parseInt(number);

        if (number <= 1) {
            console.log("The number should be greater than 1.");
        }
        else {
            if (isPrime(number)) {
                console.log(number + " is prime.");
            }
            else {
                console.log(number + " is not prime.");
            }
        }
    }
    else {
        console.log("The number is invalid");
    }
}

function isPrime(number) {
	for (var i = 2; i * i < number; ++i) {
		if (number % i == 0) {
			return false;
		}
	}
	return true;
}

function isValidInteger(number) {
    if (isFinite(number) && parseFloat(number) == parseInt(number)) {
        return true;
    }
    else {
        return false;
    }
}