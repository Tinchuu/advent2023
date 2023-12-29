const fs = require('fs');

const file = "./input.txt";
let total = 0;

const damn = fs.readFileSync(file, 'utf-8', (err, data) => {
    if (err) {
        console.error("damn");
        return;
    }
});

const lines = damn.split('\n');

lines.forEach((raw) => {
    total += solve(raw);
});

console.log(total);



function solve(line) {
    const map = new Map([
      ["one", 1],
      ["two", 2],
      ["three", 3],
      ["four", 4],
      ["five", 5],
      ["six", 6],
      ["seven", 7],
      ["eight", 8],
      ["nine", 9]
    ]);
    let start_window = 1;
    let end_window = 1;
    let start = -1;
    let end = -1;

    while (start == -1) {
        const current_check = parseInt(line[start_window - 1]);
        const sub = line.substring(0, start_window);
        for (let key of map.keys()) {
            if (sub.indexOf(key) != -1) {
                start = map.get(key);
            }
        }
        if (!isNaN(current_check)) {
            start = current_check;
            break;
        }
        start_window++;
    }

    while (end == -1) {
        const current_check = parseInt(line[line.length - end_window + 1]);
        const sub = line.substring(line.length - end_window, line.length);
        for (let key of map.keys()) {
            if (sub.indexOf(key) != -1) {
                end = map.get(key);
            }
        }
        if (!isNaN(current_check)) {
            end = current_check;
            break;
        }
        end_window++;
    }
    return parseInt(start + "" + end);
  }