class Parent:
    def __init__(self, name, address):
        self.active = True
        self.name = name
        self.address = address

    def getDetails(self):
        detail = dict()
        detail["name"] = self.name
        detail["address"] = self.address
        return detail

p = Parent("name", "xyz street")
print(type(p), p, p.getDetails())