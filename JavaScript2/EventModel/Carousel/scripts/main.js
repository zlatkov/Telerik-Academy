var carousel = (function () {
    // Use canvas to draw left arrow button
    function drawLeft() {
        var left = document.getElementsByTagName('canvas')[0].getContext('2d');
        left.lineWidth = 2;
        left.strokeStyle = 'green';
        left.fillStyle = 'white';
        left.fillRect(0, 0, left.canvas.width, left.canvas.height);
        left.strokeRect(0, 0, left.canvas.width, left.canvas.height);
        left.strokeStyle = 'blue';
        left.lineWidth = 5;
        left.beginPath();
        left.moveTo(40, 10);
        left.lineTo(40, 40);
        left.lineTo(10, 25);
        left.lineTo(40, 10);
        left.lineTo(40, 40);
        left.stroke();
    }

    // Use canvas to draw right arrow button
    function drawRight() {
        var right = document.getElementsByTagName('canvas')[2].getContext('2d');
        right.lineWidth = 2;
        right.strokeStyle = 'green';
        right.fillStyle = 'white';
        right.fillRect(0, 0, right.canvas.width, right.canvas.height);
        right.strokeRect(0, 0, right.canvas.width, right.canvas.height);
        right.strokeStyle = 'blue';
        right.lineWidth = 5;
        right.beginPath();
        right.moveTo(10, 10);
        right.lineTo(10, 40);
        right.lineTo(40, 25);
        right.lineTo(10, 10);
        right.lineTo(10, 40);
        right.stroke();
    }

    // Use canvas to draw play button
    function drawShowOn() {
        var show = document.getElementsByTagName('canvas')[1].getContext('2d');
        show.lineWidth = 2;
        show.strokeStyle = 'green';
        show.fillStyle = 'white';
        show.fillRect(0, 0, show.canvas.width, show.canvas.height);
        show.strokeRect(0, 0, show.canvas.width, show.canvas.height);
        show.fillStyle = 'blue';
        show.beginPath();
        show.moveTo(10, 10);
        show.lineTo(10, 40);
        show.lineTo(40, 25);
        show.lineTo(10, 10);
        show.lineTo(10, 40);
        show.fill();
    }

    // Use canvas to draw stop button
    function drawShowOff() {
        var show = document.getElementsByTagName('canvas')[1].getContext('2d');
        show.lineWidth = 2;
        show.strokeStyle = 'green';
        show.fillStyle = 'white';
        show.fillRect(0, 0, show.canvas.width, show.canvas.height);
        show.strokeRect(0, 0, show.canvas.width, show.canvas.height);
        show.strokeStyle = 'blue';
        show.lineWidth = 10;
        show.beginPath();
        show.moveTo(15, 10);
        show.lineTo(15, 40);
        show.moveTo(35, 10);
        show.lineTo(35, 40);
        show.stroke();
    }

    // Add event listener for onclick to the buttons
    var leftArrow = document.getElementById('canvas-left');
    leftArrow.addEventListener('click', moveLeft);
    drawLeft();

    var showArrow = document.getElementById('canvas-show');
    showArrow.setAttribute('play', 'off');
    showArrow.addEventListener('click', moveShow);
    drawShowOn();

    var rightArrow = document.getElementById('canvas-right');
    rightArrow.addEventListener('click', moveRight);
    drawRight();

    // Define images in the carousel and add the current one
    var allImages = ['images/algorithm.jpg', 'images/lamp-on.png', 'images/ninja.jpg',
        'images/software.jpg', 'images/wow.jpg'];
    var length = allImages.length;
    var index = 0;
    var interval;
    var div = document.getElementById('carousel');
    addImage(div, allImages[index]);

    // Add image to the document.body
    function addImage(element, file) {
        var image = document.createElement('img');
        image.src = file;
        image.style.height = '300px';
        image.style.width = '300px';
        element.appendChild(image);
    }

    // Change image (remove the previous and add the current)
    function changeImage() {
        var div = document.getElementById('carousel');
        var child = div.getElementsByTagName('img');
        div.removeChild(child[0]);
        addImage(div, allImages[index]);
    }

    // Define the event function when left arrow button is clicked (chenge the image with the previous one)
    function moveLeft() {
        if (index == 0) {
            index = length - 1;
        }
        else {
            index--;
        }

        changeImage(index);
    }

    // Define the event function when left arrow button is clicked (chenge the image with the next one)
    function moveRight() {
        if (index == length - 1) {
            index = 0;
        }
        else {
            index++;
        }

        changeImage(index);
    }

    // Define the event function when play button is clicked (stop or start the slide show)
    function moveShow() {
        var showArrow = document.getElementById('canvas-show');
        var state = showArrow.getAttribute('play');
        if (state === 'on') {
            showArrow.setAttribute('play', 'off');
            clearInterval(interval);
            drawShowOn();
        }
        else {
            showArrow.setAttribute('play', 'on');
            drawShowOff();
            slideShow();
        }
    }

    // Start the slide show (change the image with the next one automaticaly)
    function slideShow() {
        clearInterval(interval);
        interval = setInterval(function () {
            if (index == length - 1) {
                index = 0;
            }
            else {
                index++;
            }

            changeImage(index);
        }, 500);
    }
}());