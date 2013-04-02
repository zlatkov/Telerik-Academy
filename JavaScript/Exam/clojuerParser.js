function Solve(args) {
    var numberOfCommands = args.length, i, j;
    var result;
    var functionData = {};
    var currentLine, tmpRes;
  
    for (i = 0; i < numberOfCommands; ++i) {
        currentLine = args[i].substr(1, args[i].length - 2).replace(/\s{2,}/ig, ' ').trim();
  
        if (isOperator(currentLine[0])) {
            tmpRes = evaluateExpression(currentLine, functionData);
            if (tmpRes.terminate) {
                return 'Division by zero! At Line:' + (i + 1);
            }
            else {
            result = tmpRes.value;
        }
              
        }
        else {
            if (defineFunction(currentLine.substr(4), functionData) === false) {
                return 'Division by zero! At Line:' + (i + 1);
            }
        }
    }
    return result;
}
  
function defineFunction(line, functionData) {
    var openingBracked = false, i;
    for (i = 0; i < line.length; ++i) {
        if (line[i] === '(') {
            openingBracked = true;
            break;
        }
    }
    var functionName, tmp;
 
    if (openingBracked) {
        var seq = line.split('(');
        functionName = seq[0].trim();
 
        //console.log(functionName + ':' + seq[1].substr(0, seq[1].length - 1).trim());
 
        tmp = evaluateExpression(seq[1].substr(0, seq[1].length - 1).trim(), functionData);
        if (tmp.terminate) {
            return false;
        }
        functionData[functionName] = tmp.value;
 
    }
    else {
        var seq = line.split(' ');
        functionName = seq[0].trim();
 
        //console.log(functionName + ':' + seq[1].trim());
        functionData[functionName] = evaluateExpression(seq[1].trim(), functionData).value;
    }
    return true;
}
  
function evaluateExpression(expr, functionData) {
    //console.log(expr);
    var tmpValue = parseInt(expr);
    if (!isOperator(expr[0])) { 
        if (isFunctionName(expr)) {
            return {
                terminate: false,
                value: functionData[expr]
            };
        }
        else {
            return {
                terminate: false,
                value: parseInt(expr)
            };
        }
    }  
 
    var sequence = expr.substr(2).split(' ');
  
    for (j = 0; j < sequence.length; ++j) {
        if (isFunctionName(sequence[j].toString())) {
            sequence[j] = parseInt(functionData[sequence[j].trim()]);
        }
        else {
            sequence[j] = parseInt(sequence[j]);
        }
    }
  
    if (expr[0] === '/') {
        for (j = 1; j < sequence.length; ++j) {
            if (sequence[j] === 0) {
                return {
                    terminate: true,
                    value: 0
                };
            }
        }
    }
  
    return {
        terminate: false,
        value: applyOperator(expr[0], sequence)
    }
}
  
function applyOperator (operator, sequence) {
    var result = sequence[0], i;
    for (i = 1; i < sequence.length; ++i) {
        if (operator === '+') {
            result += sequence[i];
        }
        else if (operator === '-') {
            result -= sequence[i];
        }
        else if (operator === '*') {
            result *= sequence[i];
        }
        else {
            result = parseInt(result / sequence[i]);
        }
    }
    return result;
}
  
function isFunctionName(str) {
    for (var i = 0; i < str.length; ++i) {
        if (str[i].charCodeAt(0) < '0'.charCodeAt(0) || str[i].charCodeAt(0) > '9'.charCodeAt(0)) {
            return true;
        }
    }
    return false;
}
  
function isOperator(str) {
    return str === '+' || str === '-' || str === '*' || str === '/';
}

(function () {

    var tests = [
        [
           '(def funct 10)',
           '(def newFunct (+  funct 2))',
           '(def sumFunct (+ funct funct newFunct 0 0 0))',
           '(* sumFunct 2)',
        ],
        [
            '(def func (+ 5 2) )',
            '(def ff 4)',
            '(def func2 (/   func 5 2 1 0))',
            '(def func3  (/ func 2) )',
            '(+ func3 func)'
        ],
        [
          '(def f 1)',
          '(def fa f)',
          '(+ fa)'   
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