def invertingIntegers(input):
    
    if (type(input) != int):
        try: input = int(input)
        except: return "Invalid number"
    
    numbers = [number for number in str(input)]
    invertedInteger = []
    for number in numbers:
        if (number != '-' and number != '+'): invertedInteger.insert(0, int(number))

    isNegativeNumber = numbers[0] == '-'
    if (isNegativeNumber): invertedInteger.insert(0, '-')

    return str(invertedInteger)

print(invertingIntegers("12345678a9"));
print(invertingIntegers("+123456789"));
print(invertingIntegers("-123456789"));
print(invertingIntegers(123456789));
print(invertingIntegers(-987654321));