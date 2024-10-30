# AoC-2015

My solutions to the coding challenge [adventofcode](https://adventofcode.com/2015) written in whatever coding language my heart desired that day :)

All implemented solutions will be linked in the [Challenges table](##Challenges) with their respective languages.

---

## Challenges

| Day | Challenge                                                                     |                    C#                     |                    F#                     |                Typescript                 | Rust | Python |
| --: | :---------------------------------------------------------------------------- | :---------------------------------------: | :---------------------------------------: | :---------------------------------------: | :--: | :----: |
|   1 | [Not Quite Lisp](https://adventofcode.com/2015/day/1)                         | [Csharp](src/aoc-csharp/puzzles/Day01.cs) | [FSharp](src/aoc-fsharp/puzzles/Day01.fs) | [Typescript](src/aoc-typescript/day01.ts) | Rust | Python |
|   2 | [I Was Told There Would Be No Math](https://adventofcode.com/2015/day/2)      | [Csharp](src/aoc-csharp/puzzles/Day02.cs) | [FSharp](src/aoc-fsharp/puzzles/Day02.fs) |                Typescript                 | Rust | Python |
|   3 | [Perfectly Spherical Houses in a Vacuum](https://adventofcode.com/2015/day/3) | [Csharp](src/aoc-csharp/puzzles/Day03.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   4 | [The Ideal Stocking Stuffer](https://adventofcode.com/2015/day/4)             | [Csharp](src/aoc-csharp/puzzles/Day04.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   5 | [Doesn't He Have Intern-Elves For This?](https://adventofcode.com/2015/day/5) | [Csharp](src/aoc-csharp/puzzles/Day05.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   6 | [Probably a Fire Hazard](https://adventofcode.com/2015/day/6)                 | [Csharp](src/aoc-csharp/puzzles/Day06.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   7 | [Some Assembly Required](https://adventofcode.com/2015/day/7)                 | [Csharp](src/aoc-csharp/puzzles/Day07.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   8 | [Matchsticks](https://adventofcode.com/2015/day/8)                            | [Csharp](src/aoc-csharp/puzzles/Day08.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|   9 | [All in a Single Night](https://adventofcode.com/2015/day/9)                  | [Csharp](src/aoc-csharp/puzzles/Day09.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  10 | [Elves Look, Elves Say](https://adventofcode.com/2015/day/10)                 | [Csharp](src/aoc-csharp/puzzles/Day10.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  11 | [Corporate Policy](https://adventofcode.com/2015/day/11)                      | [Csharp](src/aoc-csharp/puzzles/Day11.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  12 | [JSAbacusFramework.io](https://adventofcode.com/2015/day/12)                  | [Csharp](src/aoc-csharp/puzzles/Day12.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  13 | [Knights of the Dinner Table](https://adventofcode.com/2015/day/13)           | [Csharp](src/aoc-csharp/puzzles/Day13.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  14 | [Reindeer Olympics](https://adventofcode.com/2015/day/14)                     | [Csharp](src/aoc-csharp/puzzles/Day14.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  15 | [Science for Hungry People](https://adventofcode.com/2015/day/15)             | [Csharp](src/aoc-csharp/puzzles/Day15.cs) |                  FSharp                   |                Typescript                 | Rust | Python |
|  16 | [Aunt Sue](https://adventofcode.com/2015/day/16)                              |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  17 | [No Such Thing as Too Much](https://adventofcode.com/2015/day/17)             |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  18 | [Like a GIF For Your Yard](https://adventofcode.com/2015/day/18)              |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  19 | [Medicine for Rudolph](https://adventofcode.com/2015/day/19)                  |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  20 | [Infinite Elves and Infinite Houses](https://adventofcode.com/2015/day/20)    |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  21 | [RPG Simulator 20XX](https://adventofcode.com/2015/day/21)                    |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  22 | [Wizard Simulator 20XX](https://adventofcode.com/2015/day/22)                 |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  23 | [Opening the Turing Lock](https://adventofcode.com/2015/day/23)               |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  24 | [It Hangs in the Balance](https://adventofcode.com/2015/day/24)               |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |
|  25 | [Let It Snow](https://adventofcode.com/2015/day/25)                           |                  Csharp                   |                  FSharp                   |                Typescript                 | Rust | Python |

---

## Usage

Depending on the language version, all that is need is to go into the respective folder and
use their common build tool to run it.

```
# these are the valid optional parameters for all implementations (can be freely combined)
 --demo      ... Use test input instead of puzzle input
 --debug     ... Show debug output
 --last      ... Show last challenge commited
 01 4 20     ... Number list specifying certain days to output
```

```zsh
# using gradle for kotlin
# or for the included gradle wrapper use gradlew (or ./gradlew on windows)
gradle run --args='01'
gradlew run --args='01'

# using dotnet for c# and f#
dotnet run -- --demo

# using cargo for rust
cargo run -- 01

# using ts-node for typescript
ts-node filename.ts

# using python3 for python
python3 main.py --debug
```

## Languages used in this challenge

- C# 12.0 (.NET 8)
- F# 8.0 (.NET 8)

## Folder structure

```
+---data
|   +---demo
|       - day01.txt
|       - ...
|   +---real
|       - day01.txt
|       - ...
+---src
|   +---aoc-csharp
|   +---aoc-fsharp
+---dump
|   - AoC.sln
- README.md
- .gitignore
```

## Sample output

```log
------------------------------------------------------------------------------
AdventOfCode Runner for 2015
Challenge at: https://adventofcode.com/2015/
Author: Johannes Wöß
------------------------------------------------------------------------------
|  Day  |         1st |         2nd |
| Day01 |        1624 |        1653 |
Could not find solution for day Day02
```
