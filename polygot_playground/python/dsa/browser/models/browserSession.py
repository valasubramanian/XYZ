from dataclasses import dataclass, field
from browserPage import BrowserPage

@dataclass
class BrowserSession:
    history: BrowserPage = field(default=None)

    def NewPage(self, page: BrowserPage):
        def setActivePage(page: BrowserPage, newPage: BrowserPage):
            if (page != None):
                page.Active = False
                if (page.Next != None): setActivePage(page.Next, newPage)
                else: page.Next = newPage

        isRootPage = self.history == None
        if (isRootPage): self.history = page
        else: setActivePage(self.history, page)

    def GoBack(self):      
        def setBackPage(page: BrowserPage):
            if (page != None):
                if (page.Next != None and page.Next.Active): 
                    page.Active = True
                    page.Next.Active = False
                else: setBackPage(page.Next)
        
        setBackPage(self.history)

    def GoNext(self):
        def setNextPage(page: BrowserPage):
            if (page != None):
                if (page.Active and page.Next != None): 
                    page.Active = False
                    page.Next.Active = True
                else: setNextPage(page.Next)
        
        setNextPage(self.history)

            





