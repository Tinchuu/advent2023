use std::fs::read_to_string;

pub fn part_one() {
    let binding = read_to_string("input.txt").unwrap();
    let mut lines = binding.lines();
    let raw_seeds: Vec<&str> = lines.next().unwrap().split(": ").collect();
    let str_seeds: Vec<&str> = raw_seeds.get(1).unwrap().split(" ").collect();
    let mut seeds: Vec<u64> = str_seeds.iter().map(|s| s.parse().unwrap()).collect();
    println!("{:?}", seeds);
    let mut temp_seeds = seeds.clone();
    
    for line in lines {
        if let Some(first_char) = line.chars().next() {
            if first_char.is_digit(10) {
                let raw_nums: Vec<&str> = line.split_whitespace().collect();
                let nums: Vec<u64> = raw_nums.iter().map(|&s| s.parse().unwrap()).collect();

                for i in 0..seeds.len() {
                    if let Some(seed) = seeds.get(i) {
                        if *seed >= nums[1] && *seed < nums[1] + nums[2] {
                            let dif = seed - &nums[1];
                            println!("{:?}, matching {:?}", seed, nums);
                            temp_seeds[i] = nums[0] + dif;
                            println!("{:?}", temp_seeds);
                        }
                    }
                }
            } else {
                if line != "" {
                    println!("update");
                    seeds = temp_seeds;
                    temp_seeds = seeds.clone();
                }
            }
        }
    }
    seeds = temp_seeds;
    seeds.sort();

    println!("{:?}", seeds);
}