# Python variables
x, y, z = 10, 11, 12
xyz = 3298

def firstFunction():
    global xyz, abc, shouldAbc
    shouldAbc = True
    abc = xyz
    xyz = x + y + z
    isFnExecuted = True 
    return isFnExecuted

def secondFunction():
    if (shouldAbc):
        print(abc)
    if(isFnExecuted or isFirstFnExecuted): # error -> 'isFnExecuted' is not defined
        print('firstFunction Executed')

isFirstFnExecuted = firstFunction()
print(isFirstFnExecuted)
print(x + y + z)
print(x, y, z)
x = "10"
y = "11"
z = '12'
print(x + y + z)
print(x, y, z)
print(xyz)
if(isFirstFnExecuted):
    secondFunction()

"""
End
of
Program
"""