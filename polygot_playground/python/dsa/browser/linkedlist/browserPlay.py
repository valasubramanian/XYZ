from browser import Browser

opera = Browser()
opera.Go("www.google.com")
opera.Go("www.stackoverflow.com")
opera.Go("www.microsoft.com")
opera.Go("www.csharpcorner.com")
opera.Back()
opera.Back()
opera.Back()
opera.Next()
opera.Go("www.youtube.com")

print(opera.GetHistory())