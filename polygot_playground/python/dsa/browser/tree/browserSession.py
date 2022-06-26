from dataclasses import dataclass, field
from browserPage import BrowserPage
from browserPageBranch import BrowserPageBranch

@dataclass
class BrowserSession:
    history: BrowserPage = field(default=None)
    rootBranch: BrowserPageBranch = field(default=None)

    def NewPage(self, page):
        # def setActivePage(page: BrowserPage, newPage: BrowserPage):
        #     if (page != None):
        #         page.Active = False
        #         if (page.Next != None): setActivePage(page.Next, newPage)
        #         else: page.Next = newPage

        def setActivePage(branch: BrowserPageBranch, newPage: BrowserPage):
            if (branch != None):
                if (branch.ActiveBranch):
                     
                if (page.Next != None): setActivePage(page.Next, newPage)
                else: page.Next = newPage

        isRootPage = self.rootBranch == None
        if (isRootPage): self.rootBranch = BrowserPageBranch(page)
        else: setActivePage(self.rootBranch, page)

    def GoBack(self):      
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

            





