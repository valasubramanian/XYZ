
def findMissingNumber(input):
    if (type(input) != list):
        input = [int(number) for number in input.split(",")]

    length, missedNumbers = len(input), []
    for index, number in enumerate(input):
        if (index < length - 1):
            difference = input[index + 1] - number
            for start in range(1, difference): missedNumbers.append(number + start)

    return missedNumbers

print(findMissingNumber("1, 2, 3, 4, 6, 7, 8, 10"));
print(findMissingNumber([1, 3, 4, 6, 7, 8, 9, 10]));
print(findMissingNumber([1, 2, 3, 4, 7, 10]));