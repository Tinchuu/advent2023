const fs = require('fs');

const file = "./test.txt";
let total = 0;

const damn = fs.readFileSync(file, 'utf-8', (err, data) => {
    if (err) {
        console.error("damn");
        return;
    }
});

const lines = damn.split('\n');

lines.forEach((line) => {
    const len = line.length;
    let start = 0;
    let end = 0;
    for (let i = 0; i < len; i++) {
        const current = parseInt(line[i]);
        if (!isNaN(current)) {
            start = current;
            break;
        }
    }
    for (let i = len - 1; i >= 0; i--) {
        const current = parseInt(line[i]);
        if (!isNaN(current)) {
            end = current;
            break;
        }
    }
    line_string = start + '' + end;
    total += parseInt(line_string);
});

console.log(total);
