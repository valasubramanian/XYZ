from dataclasses import dataclass, field
from browserPage import BrowserPage

@dataclass
class BrowserPageBranch:
    ActiveBranch: bool = False
    Root: BrowserPage = field(default=None)

     def __init__(self, page):
         self.Root = page
         self.ActiveBranch = True

