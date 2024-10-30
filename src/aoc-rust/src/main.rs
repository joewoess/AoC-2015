use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let grid = read_file_to_grid("path/to/puzzle.txt");
    let target_char = 'a'; // replace with your target character

    match find_char(&grid, target_char) {
        Some((x, y)) => println!("Found {} at ({}, {})", target_char, x, y),
        None => println!("Character not found"),
    }
}

fn read_file_to_grid<P>(filename: P) -> Vec<Vec<char>>
where
    P: AsRef<Path>,
{
    let mut grid = Vec::new();
    if let Ok(lines) = read_lines(filename) {
        for line in lines {
            if let Ok(ip) = line {
                grid.push(ip.chars().collect::<Vec<char>>());
            }
        }
    }
    grid
}

fn read_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
where
    P: AsRef<Path>,
{
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn find_char(grid: &Vec<Vec<char>>, target: char) -> Option<(usize, usize)> {
    for (i, row) in grid.iter().enumerate() {
        for (j, &c) in row.iter().enumerate() {
            if c == target {
                return Some((i, j));
            }
        }
    }
    None
}
