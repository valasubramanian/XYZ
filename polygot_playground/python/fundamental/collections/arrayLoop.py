array = ["A", "B", "C", "D", "E", "Z"]
for i in range(len(array)):
  print(array[i])

print([item for item in array])
[print(item) for item in array]
print([index for index, item in enumerate(array)])

# array filtering
fruits = ["apple", "banana", "cherry", "kiwi", "mango"]
newlist = [x for x in fruits if "a" in x]
print(newlist)
print([x.upper() for x in fruits if "a" in x])

# array manipulation
print([x if x == "apple" else x.upper() for x in fruits])
print([x if x != "banana" else "BananA" for x in fruits])

# sorting
fruits.sort(reverse=True)
print(fruits)
fruits.sort()
print(fruits)
fruits.reverse()
print(fruits)

print([x for x in range(10)])