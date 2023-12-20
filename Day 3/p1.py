content = open("input.txt").read()

lines = content.splitlines()
grid = []

for line in lines:
    grid.append([char for char in line])

y_max = len(lines)
x_max = len(lines[0])

def check_number(grid, x_min, x_max, y):
    y_low = y - 1 if y > 0 else y
    y_high = y + 2 if y < len(grid) - 1 else y
    x_low = x_min - 1 if x_min > 0 else x_min
    x_high = x_max + 2 if x_max < len(grid[0]) - 1 else x_max
    for i in range(y_low, y_high):
        for j in range(x_low, x_high):
            try:
                int(grid[i][j])
                continue
            except ValueError:
                if (grid[i][j] != "."):
                    return True
    return False

total = 0

for y in range(y_max):
    x = 0
    while x < x_max:
        try:
            int(grid[y][x])
            min = x
            max = x
            while True:
                x += 1
                if x >= x_max:
                    break
                try: 
                    int(grid[y][x])
                    max = x
                except ValueError:
                    break
            print(min, max, y)
            if check_number(grid, min, max, y):
                total += int(''.join(grid[y][min:max + 1]))

        except ValueError:
            x += 1
            continue

print(total)