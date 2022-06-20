from dataclasses import dataclass, field
from browserPage import BrowserPage

@dataclass
class BrowserPageBranch:
    Active: bool = False
    Next: BrowserPage = field(default=None)

