```mermaid

---
title: PlayerManager
---

classDiagram

class Player
class PlayersList
class UglyView
class IView
<<interface>> IView
class Controller
class Program

UglyView --|> IView
Program *-- UglyView
Program *-- Controller
Program *-- PlayersList
Controller ..> UglyView
Controller --> Player