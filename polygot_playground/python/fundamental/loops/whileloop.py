# The break statement "jumps out" of a loop.
# The continue statement "jumps over" one iteration in the loop.

i = 1
while i < 6:
  print(i)
  i += 1
else:
  print("i is no longer less than 6")

i = 1
while i < 6:
  print(i)
  i += 1
  if(i == 6): continue
else:
  print("i is no longer less than 6")

i = 1
while i < 6:
  print(i)
  i += 1
  if(i == 6): break
else:
  print("i is no longer less than 6")