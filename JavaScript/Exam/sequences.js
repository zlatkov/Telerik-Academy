function Solve(args) {
    var n = parseInt(args[0]);
    var seq = [], i;
    for (i = 1; i <= n; ++i) {
        seq.push(parseInt(args[i]));
    }

    var result = 1;
    for (i = 1; i < n; ++i) {
        if (seq[i] < seq[i - 1]) {
            result++;
        }
    }
    return result;

}


(function () {

    var tests = [
        [
           '7', 
           '1', '2', '-3', '4', '4', '0', '1'
        ],
        [
            '6', 
            '1', '3', '-5', '8', '7', '-6'
        ],
        [
            '9', 
            '1', '8', '8', '7', '6', '5', '7', '7', '6'
        ],
        [
            '1',
            '0'
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

