from dataclasses import dataclass
from browserPage import BrowserPage
from browserSession import BrowserSession
from typing import List

@dataclass
class Browser:
    session = None

    def __init__(self):
        self.session = None

    def Go(self, url):
        isNewSession = self.session == None
        if (isNewSession):
            self.session = BrowserSession()

        newPage = BrowserPage(url)
        self.session.NewPage(newPage)

    def Back(self):
        self.session.GoBack()

    def Next(self):
        self.session.GoNext()

    def NewTab():
        pass

    def Close():
        pass

    def GetHistory(self):
        return self.session.history

