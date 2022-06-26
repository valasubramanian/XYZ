from dataclasses import dataclass, field
from browserPage import BrowserPage

@dataclass
class BrowserSession:
    history: BrowserPage = field(default=None)

    def NewPage(self, page):
        isRootPage = self.history == None
        if (isRootPage): self.history = page
        else: self.history.AppendNewPage(page)

    def GoBack(self):
        self.history.GoBack()

    def GoNext(self):
        self.history.GoNext()

            





