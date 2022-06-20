from dataclasses import dataclass
from typing import List

@dataclass
class BrowserPage:
    Url: str
    Title: str
    Active: bool
    Next: None
    Branches: list

    def __init__(self, url: str):
        self.Url = url
        self.Title = self.GetTitle(url)
        self.Active = True
        self.Next = None
        self.Branches = list()

    def GetTitle(self, url: str):
        urlParts = url.split('.')
        return urlParts[1].capitalize()


