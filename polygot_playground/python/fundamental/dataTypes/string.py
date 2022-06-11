"""
    Python String Data Type
"""
string = "Valasubramanian \"Sunmugavel\""
stringAsObject = str("Valasubramanian \"Sunmugavel\"")
stringMultiline = """Lorem ipsum dolor sit amet,
consectetur adipiscing elit,
sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua."""

print(string)
print(stringAsObject)
print(stringMultiline)
print(string == stringAsObject)
print(string[0] + string[17])
print(string[0:15], string[:15])
print(string[16:])
print(string[60:94])
print(len(string[60:94]))
print(len(string))
print(str(" Vala ").strip(), len(str(" Vala ").strip()))
print(string.replace('V', 'B').replace('a', 'u').replace('b', 'V'))
print(string.split())
print(string.split('"'))
print(str("{} " + string).format("Hello"))
print(string.count("Valasubramanian"))
print(string.find("Valasubramanian"), string.find("valasubramanian"), string.find("balasubramanian"))
print(string.find("s"))

array, indexes = list(), list()
for index, char in enumerate(string):
    indexes.append(index)
    array.append(char.upper())

arr = [char for char in string]

print(arr)
print(array)
print(indexes)

