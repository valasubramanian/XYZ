a, b = 33, 200
if b > a: print("b is greater than a")
else:
    print("a is greater than b")

a = 201
print("a is greater than b") if a > b else print("b is greater than a")

b > a and print("b is greater than a")
b < a and print("a is greater than b")

ABC = "ABC"
if "X" in ABC: print("X is there")
elif "Y" in ABC: print("Y is there")
elif "Z" in ABC: print("Z is there")
else: print("XYZ is not there")

liste = []
if len(liste) == 0: 
    liste.append(1)
    print('liste is empty')
else:
    print('liste is not empty')