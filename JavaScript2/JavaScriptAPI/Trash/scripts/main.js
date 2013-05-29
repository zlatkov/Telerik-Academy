(function () {
    var trashBin = (function () {
        var self = this;

        function initialize(parentElementId, trashItemsPanel) {
            self.parentElement = document.getElementById(parentElementId);
            self.trashItemsPanel = trashItemsPanel;
            self.trashBin = document.createElement("img");
            self.trashBin.src = "img/trashbin-closed.png";
            self.trashBin.style.width = "200px";
            self.trashBin.style.height = "350px";
            self.parentElement.appendChild(self.trashBin);

            addEventListeners();
        }

        function closeTrashBin() {
            self.trashBin.src = "img/trashbin-closed.png";
        }

        function openTrashBin() {
            self.trashBin.src = "img/trashbin-opened.png";
        }
       

        function addEventListeners() {
            self.trashBin.addEventListener("dragenter", function(event) {
                openTrashBin();
                event.dropEffect = "move";
            }, false);

            self.trashBin.addEventListener("dragover", function(event) {
                event.preventDefault();
            }, false);

            self.trashBin.addEventListener("dragleave", function(event) {
                closeTrashBin();
            }, false);

            self.trashBin.addEventListener("drop", function (event) {
                event.preventDefault();
                var draggedItem = document.getElementById(event.dataTransfer.getData("trash-item-id"));
                self.trashItemsPanel.removeChild(draggedItem);
                closeTrashBin();

                dispatchEvent(new CustomEvent("itemDropped", {
                    detail: {},
                    bubbles: true,
                    cancelable: true
                }));

            }, false);
        }

        return {
            initialize: initialize
        }
    })();

    var trashItemManager = (function () {
        var self = this;
        self.itemsCount = 0;

        function getRandomInt(min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }

        function createTrashItem(parentPanel) {
            var newTrashItem = document.createElement("img");
            newTrashItem.src = "img/paper-item.png";
            newTrashItem.style.width = "40px";
            newTrashItem.style.height = "40px";

            newTrashItem.style.position = "absolute";
            newTrashItem.style.top = getRandomInt(200, window.innerHeight - 50) + "px";
            newTrashItem.style.left = getRandomInt(200, window.innerWidth - 50) + "px";

            newTrashItem.draggable = true;
            newTrashItem.id = "trash-item-" + self.itemsCount++;
            parentPanel.appendChild(newTrashItem); 
        }

        return {
            createTrashItem: createTrashItem
        }
    })();

    var timer = (function() {
        var self = this;
        var isRunning = false;
        var totalTimeElapsed = 0;

        function initialize(elementId) {
            self.timerElement = document.getElementById(elementId); 
        }

        function start() {
            isRunning = true;
            totalTimeElapsed = 0;

            self.startTime = new Date();
            self.intervalRef = setInterval(function () {
                var currentTime = new Date();
                var timeElapsed = Math.round((currentTime - self.startTime) / 1000);
                totalTimeElapsed = timeElapsed;
                self.timerElement.innerHTML = timeElapsed + " seconds.";
            }, 1000);
        }

        function stop() {
            clearInterval(self.intervalRef);
            isRunning = false;
        }

        function hasStarted() {
            return isRunning;
        }

        function totalTime() {
            return totalTimeElapsed;
        }

        return {
            initialize: initialize,
            start: start,
            stop: stop,
            hasStarted: hasStarted,
            totalTime: totalTime
        }
    })();

    var gameManager = (function () {
        var self = this;
        var totalTrashItemsCount = 20;
        var trashItemsCollected = 0;

        timer.initialize("timer");
        var scoreBoard = document.getElementById("scoreboard-panel");

        updateScoreBoard();

        document.addEventListener("dragstart", function (event) {
            event.dataTransfer.effectAllowed = "move";
            event.dataTransfer.setData("trash-item-id", event.target.id);

            if (!timer.hasStarted()) {
                timer.start();
            }
        }, false);

        function startGame() {
            var trashItemsPanel = document.getElementById("trash-items-panel");
          
            for (var i = 0; i < totalTrashItemsCount; i += 1) {
                trashItemManager.createTrashItem(trashItemsPanel);
            }
            trashItemsCollected = 0;

            trashBin.initialize("trashbin-panel", trashItemsPanel);

            self.addEventListener("itemDropped", function () {
                trashItemsCollected++;
                if (trashItemsCollected === totalTrashItemsCount) {
                    gameOver();
                }
            }, false);
        }

        function updateScoreBoard() {
            scoreBoard.innerHTML = "";
            var displayString = "";
            var i, usersData = [];
            for (i = 0; i < localStorage.length; i += 1) {
                var currentKey = localStorage.key(i);
                usersData.push({
                    name: currentKey,
                    score: localStorage[currentKey]
                })
            }
            

            usersData.sort(function (a, b) {
                return a.score - b.score;
            });

            var playersToDisplay = Math.min(5, usersData.length);
            for (i = 0; i < usersData.length; i += 1) {
                if (i > 0) {
                    displayString += ", ";
                }
                displayString += usersData[i].name + ": " + usersData[i].score;
            }
            scoreBoard.innerHTML = displayString;
        }

        function gameOver() {
            timer.stop()
            var userName = prompt("Enter yout name:");
            var userScore = timer.totalTime();

            localStorage[userName] = userScore;
            updateScoreBoard();
        }

        return {
            startGame: startGame
        }
        
    })();

    gameManager.startGame();
})(); 