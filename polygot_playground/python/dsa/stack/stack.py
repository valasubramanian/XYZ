from dataclasses import dataclass

@dataclass
class Stack:
    stackArray = []

    def push(self, item):
        self.stackArray.append(item)

    def pop(self):
        self.stackArray.pop()

    def get(self):
        return self.stackArray
        