
arrayOfVala = [ "vala", "subramanian", 1991]
newArrayOfVala = arrayOfVala + [ "developer", "cricket", "indian"]
print(arrayOfVala)
print(newArrayOfVala)
fname, lname, yob = arrayOfVala
print(fname, lname, yob)
print(len(arrayOfVala))
print(arrayOfVala[0])
print(arrayOfVala[0:2])
print(arrayOfVala[2:3])

thislist = list(("apple", "banana", "cherry"))
print(thislist[-1])
thislist2 = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist2[-4:-1])

arrayOfKevin = [ "kevin", "sambath", 1992 ]
arrayOfKevin.extend([ "developer", "cricket", "indian" ])
print(arrayOfKevin)

arrayOfValaAndKevin = arrayOfVala + arrayOfKevin
print(arrayOfValaAndKevin)

arrayOfArray = [arrayOfVala, arrayOfKevin]
print(arrayOfArray)

if "vala" in arrayOfValaAndKevin:
    print("Vala is here")