from dataclasses import dataclass
from typing import List

@dataclass
class BrowserPage:
    Url: str
    Title: str
    Active: bool
    Parent = None
    Childrens = None

    def __init__(self, url):
        self.Url = url
        self.Title = self.GetTitle(url)
        self.Active = True

    def GetTitle(self, url):
        urlParts = url.split('.')
        return urlParts[1].capitalize()

    def AppendNewPage(self, newPage):
        if self.Active:
            self.Active = False
            if self.Childrens == None:
                self.Childrens = []
                self.Childrens.append(newPage)
            else:
                self.Childrens.insert(0, newPage)
        else:
            self.Childrens[0].AppendNewPage(newPage)
    
    def GoBack(self):
        if self.Active == False and len(self.Childrens) > 0:
            if self.Childrens[0].Active:
                self.Active = True
                self.Childrens[0].Active = False
            else: self.Childrens[0].GoBack()
    
    def GoNext(self):
        if len(self.Childrens) > 0:
            if self.Active:
                self.Active = False
                self.Childrens[0].Active = True
            else: self.Childrens[0].GoNext()
    
    def PrintHistory(self):
        print(self)
        if self.Childrens != None:
            self.Childrens[0].PrintHistory()


