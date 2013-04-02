function Solve(args) {
    console.log('yes');
    var line0 = args[0].split(' ');
    var line1 = args[1].split(' ');

    var n = parseInt(line0[0]);
    var m = parseInt(line0[1]);
    var jumpsCount = parseInt(line0[2]);

    var currentX = parseInt(line1[0]) + 1;
    var currentY = parseInt(line1[1]) + 1;

    var jumps = [], i, j, tmp;
    for (i = 0; i < jumpsCount; ++i) {
        tmp = args[2 + i].split(' ');
        jumps.push([parseInt(tmp[0]), parseInt(tmp[1]) ]);
    }

    var visited = [];
    for (i = 0; i <= n; ++i) {
        visited[i] = [];
    }

    var nextX, nextY, score = 0, escaped = false, jumpIndex = 0;

    while (true) {

        if (currentX < 1 || currentX > n || currentY < 1 || currentY > m) {
            escaped = true;
            break;
        }
        else if (visited[currentX][currentY] === true) {
            escaped = false;
            break;
        }

        score += (currentX - 1) * m + currentY;
        currentX += jumps[jumpIndex][0];
        currentY += jumps[jumpIndex][1];
        jumpIndex = (jumpIndex + 1) % jumpsCount;
    }

    if (escaped) {
        return 'escaped ' + score;
    }
    else {
        return 'caught ' + score;
    }
}


(function () {

    var tests = [
        /*[
            '6 7 3',
            '0 0',
            '2 2',
            '-2 2',
            '3 -1'  
        ],*/
        [
            '2 2 2',
            '0 0',
            '1 1',
            '-1 -1'
        ],
        [
            
        ]
    ];

    for (var i in tests) {
        if (tests[i].length > 0) {
            console.log('Running test number: ' + i);
            console.log('Test data:\n' + tests[i]);
            console.log('Output: ');
            console.log(Solve(tests[i]) + '\n');
        }
    }
})()

