import datetime

x = datetime.datetime.now()
print(x)
print(x.year)
print(x.strftime("%A"))
print(x.strftime("%B"))
print(x.strftime("%d-%B-%Y %I:%M %p"))

x = datetime.datetime(2020, 5, 17)
print(x)