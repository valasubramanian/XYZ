"""
    Python Datatypes: Every built-in data type is an object
        Text Type:	str
        Numeric Types:	int, float, complex
        Sequence Types:	list, tuple, range
        Mapping Type:	dict
        Set Types:	set, frozenset
        Boolean Type:	bool
        Binary Types:	bytes, bytearray, memoryview
        None Type:	NoneType
"""
# int abc = 12
x, x2 = 10, int('20')
f, l = float('10.123'), complex('123984923.122348927498237897289234892398479823743')
y = str(10)
z = bool(0)
lists = [10, 11, 12]
xyz, abc = dict({ 'name': 'vala', 'age': 32 }), dict(name="John", age=36)
sets = set(['1', '2', '2', '3'])
arrDictn = [dict(name="John", age=36), dict(name="Dave", age=31)]
none = None
def hello():
    print("hello")

print(type(x), type(y), type(z), type(xyz), type(lists), type(abc), type(arrDictn), type(none), type(hello))
print(x + x2)
print(x + x2 + f)
print(x, x2, y, z)
print(l)
print(xyz)
print(abc)
print(sets)
print(none == None)

arrDictn.append(dict(name="Keve", age=54))
print(arrDictn)