from parentclass import Parent

class Child(Parent):
    def __init__(self, name, address, age):
        super().__init__(name, address)
        self.age = age

    def getDetails(self):
        detail = dict()
        detail["name"] = self.name
        detail["address"] = self.address
        detail["age"] = self.age
        return detail

    def setFullname(self, fullName):
        self.fullName = fullName

    def getFullname(self):
        if hasattr(self, 'fullName') : return self.fullName


child = Child("Vala", "Tirunelveli", 26)
print(child.getDetails())

child.age = 27
print(child.getDetails())

print(child.getFullname())
child.setFullname("Valasubramanian")
print(child.getFullname())