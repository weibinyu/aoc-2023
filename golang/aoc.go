package main

import (
    "bufio"
    "fmt"
    "os"
    "strconv"
	"unicode"
)

func check(e error) {
    if e != nil {
        panic(e)
    }
}

func makeNumberMap()(map[string]int){
    numberMap := make(map[string]int)
	numberMap["one"] = 1
    numberMap["two"] = 2
    numberMap["three"] = 3
    numberMap["four"] = 4
    numberMap["five"] = 5
    numberMap["six"] = 6
    numberMap["seven"] = 7
    numberMap["eight"] = 8
    numberMap["nine"] = 9
    return numberMap
}

func getLineValueInt(line string,m map[string]int) (int, error) {
	// Initialize variables to store the first and last integers
	var first, last string 
	var err error

	// Iterate through the string to find the first integer
    for _ , r := range line {
		if unicode.IsDigit(r) {
			first = string(r)
			break
		}
	}

	// Iterate through the string in reverse to find the last integer
	for i := len(line) - 1; i >= 0; i-- {
		if unicode.IsDigit(rune(line[i])) {
			last = string(line[i])
			break
		}
	}
    //a for loop here that iterate throught number string array and use index
    //to determine what number it is

    value,err := strconv.Atoi(first+last)
    check(err)

	return value, err
}

func main() {
    file,err := os.Open("D:/neoVimDir/aoc-2023/inputs/day1.txt")
    check(err)

    defer file.Close()

    total := 0
    scanner := bufio.NewScanner(file)
    numberMap := makeNumberMap()

    for scanner.Scan() {
       value, err := getLineValueInt(scanner.Text(),numberMap)
       total += value
       check(err)
    }
    fmt.Println(total)
}
    
