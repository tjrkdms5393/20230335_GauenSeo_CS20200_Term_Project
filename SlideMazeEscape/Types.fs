module SlideMazeEscape.Types

type Position = {
  Row: int
  Col: int
}

type Direction =
  | Up
  | Left
  | Down
  | Right

type MazeMap = {
  Name: string
  Difficulty: string
  Walls: (Position * Position) list
}

type GameState = {
  Player: Position
  Start: Position
  Exit: Position
  Map: MazeMap
}