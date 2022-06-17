from dataclasses import dataclass

@dataclass
class BrowserPage:
    Url: str
    Title: str
    Active: bool
    Next = None

    def __init__(self, url):
        self.Url = url
        self.Title = self.GetTitle(url)
        self.Active = True
        self.Next = None

    def GetTitle(self, url):
        urlParts = url.split('.')
        return urlParts[1].capitalize()


