# // Input: [1,2,3]
# // Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

def permute(array):
  results = []
  def go(current):
    if(len(current) == len(array)):
      results.append(current)
      return
    for n in array:
      if not (n in current):
        temp = [t for t in current]
        temp.append(n)
        go(temp)
  
  go([])
  return results

print(permute([1,2,3]));