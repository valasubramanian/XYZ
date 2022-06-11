# change items
array = ["A", "B", "C", "D", "E", "Z"]
array[0] = 1
print(array)

array[0:1] = ["A"]
print(array)

array[0:2] = ["A"]
print(array)

array[0:1] = ["A", "B"]
print(array)

array[4:5] = ["F", "G"]
print(array)

array[4:5] = ["E", "F"]
print(array)

# insert items
array.insert(0, "->")
print(array)

array.insert(len(array), "<-")
print(array)

# append items
array.append("end")
print(array)

# remove items
array.pop(0)
array.pop(-2)
array.pop()
# array.remove("a")
print(array)

# clear items
array.clear()
print(array)