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