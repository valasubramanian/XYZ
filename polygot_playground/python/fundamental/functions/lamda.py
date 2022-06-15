x = lambda a, b : a * b
print(x(5, 6))

def myfunc(n):
  return lambda a : a * n

mydoubler = myfunc(2) # n is 2
mytripler = myfunc(3) # n is 3


print(mydoubler(0)) # a is 0
print(mydoubler(6)) # a is 6
print(mytripler(11)) # a is 11