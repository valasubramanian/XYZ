import json

x =  '{ "name":"John", "age":30, "city":"New York"}'
y = json.loads(x)
print(type(y), y, y["age"])

dictobj = {
  "name": "John",
  "age": 30,
  "married": True,
  "divorced": False,
  "children": ("Ann","Billy"),
  "pets": None,
  "cars": [
    {"model": "BMW 230", "mpg": 27.5},
    {"model": "Ford Edge", "mpg": 24.1}
  ]
}
y = json.dumps(dictobj)
print(type(y), y)