set1 = {"apple", "banana", "cherry", "apple"}
set2 = {0, 5, 7, 9, 3}
set3 = {True, False, False}
print(set1, set2, set3)
print(set1.union(set2).union(set3))

set1.add("cherry")
set1.add("mango")
print(set1)

set4 = set1.copy()
set4.update(set2)
print(set4)

set1.remove("banana")
set1.discard("banana")
print(set1)

set1.pop()
print(set1)

if("cherry" in set1):
    print("Have a cherry")

set1.clear()
print(set1)