function onClick(event, arguments) {
	var currentWindow = window;
	var currentBrowserName = currentWindow.navigator.appCodeName;
	var browserIsMozzilla = (currentBrowserName == "Mozilla");	
	if (browserIsMozzilla) {
		alert("Yes");
	} else {
		alert("No");
	}
}