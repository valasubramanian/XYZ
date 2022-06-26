from dataclasses import dataclass
from typing import List

@dataclass
class BrowserPage:
    Url: str
    Title: str
    Active: bool
    Next: None

    def __init__(self, url):
        self.Url = url
        self.Title = self.GetTitle(url)
        self.Active = True
        self.Next = None

    def GetTitle(self, url):
        urlParts = url.split('.')
        return urlParts[1].capitalize()

    def AppendNewPage(self, newPage):
        self.Active = False
        if (self.Next != None): self.Next.AppendNewPage(newPage)
        else: self.Next = newPage
    
    def GoBack(self):
        if self.Next != None:
            if self.Next.Active: 
                self.Active = True
                self.Next.Active = False
            else: self.Next.GoBack()
    
    def GoNext(self):
        if self.Next != None:
            if self.Active: 
                self.Active = False
                self.Next.Active = True
            else: self.Next.GoNext()


