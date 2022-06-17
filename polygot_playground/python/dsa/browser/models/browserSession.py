from dataclasses import dataclass
from browserPage import BrowserPage

@dataclass
class BrowserSession:
    def __init__(self):
        self.history = None

    def NewPage(self, page):
        isRootPage = self.history == None
        if (isRootPage): self.history = page
        else:
            self.SetActivePage(self.history, page)

    def SetActivePage(self, page, newPage):
        if (page != None):
            page.Active = False
            if (page.Next != None): self.SetActivePage(page.Next, newPage)
            else: page.Next = newPage

    def GoBack(self, to = None):      
        def setBackPage(page):
            if (page != None):
                if (page.Next != None and page.Next.Active): 
                    page.Active = True
                    page.Next.Active = False
                else: setBackPage(page.Next)
        
        setBackPage(self.history)

    def GoNext(self):
        def setNextPage(page):
            if (page != None):
                if (page.Active and page.Next != None): 
                    page.Active = False
                    page.Next.Active = True
                else: setNextPage(page.Next)
        
        setNextPage(self.history)

            





