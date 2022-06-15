def myFunction(title, name = ""):
    return "Hey " + title + " " + name

print(myFunction("Mr."))
print(myFunction("Mr.", "Vala"))
print(myFunction(name="Valasubramanian", title="Mr."))

def myFunctionFor(title, *names):
    fullnames = [name for name in names]
    return "Hey " + title + " " + ''.join(fullnames)

def myFunctionSpace(title, *names):
    return "Hey " + title + " " + ''.join(str(name + " ") for name in names)

print(myFunctionFor("Mr.", "Bala"))
print(myFunctionFor("Mr.", "Bala", "subramanian"))
print(myFunctionSpace("Mr.", "Bala", "subramanian"))


def myFunctionObject(**object):
    return "Hey " + object["title"] + " " + object["fname"]

print(myFunctionObject(fname="Karthi", title="Mr."))