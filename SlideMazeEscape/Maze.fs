module SlideMazeEscape.Maze

open SlideMazeEscape.Types

let size = 8

let startPos = { Row = size; Col = 2 }
let exitPos = { Row = -1; Col = 6 }

let samePosition p1 p2 =
  p1.Row = p2.Row && p1.Col = p2.Col

let isInside pos =
  0 <= pos.Row && pos.Row < size &&
  0 <= pos.Col && pos.Col < size

let isSpecialOutsidePosition pos =
  samePosition pos startPos || samePosition pos exitPos

let isValidPosition pos =
  isInside pos || isSpecialOutsidePosition pos

let hasWallBetween walls p1 p2 =
  walls
  |> List.exists (fun (a, b) ->
    (samePosition a p1 && samePosition b p2) ||
    (samePosition a p2 && samePosition b p1))

// ------------------------------------------------------------
// Easy map
// ------------------------------------------------------------

let easyWalls : (Position * Position) list = [
  // Horizontal walls
  ({ Row = 2; Col = 5 }, { Row = 2; Col = 6 })
  ({ Row = 3; Col = 4 }, { Row = 3; Col = 5 })
  ({ Row = 4; Col = 6 }, { Row = 4; Col = 7 })
  ({ Row = 6; Col = 3 }, { Row = 6; Col = 4 })
  ({ Row = 7; Col = 3 }, { Row = 7; Col = 4 })

  // Vertical walls
  ({ Row = 5; Col = 0 }, { Row = 6; Col = 0 })
  ({ Row = 1; Col = 1 }, { Row = 2; Col = 1 })
  ({ Row = 5; Col = 1 }, { Row = 6; Col = 1 })
  ({ Row = 1; Col = 2 }, { Row = 2; Col = 2 })
  ({ Row = 1; Col = 3 }, { Row = 2; Col = 3 })
  ({ Row = 3; Col = 3 }, { Row = 4; Col = 3 })
  ({ Row = 3; Col = 4 }, { Row = 4; Col = 4 })
  ({ Row = 6; Col = 5 }, { Row = 7; Col = 5 })
  ({ Row = 0; Col = 7 }, { Row = 1; Col = 7 })
  ({ Row = 6; Col = 7 }, { Row = 7; Col = 7 })
]

// ------------------------------------------------------------
// Medium map
// ------------------------------------------------------------

let mediumWalls : (Position * Position) list = [
  // Horizontal walls
  ({ Row = 0; Col = 4 }, { Row = 0; Col = 5 })
  ({ Row = 1; Col = 0 }, { Row = 1; Col = 1 })
  ({ Row = 2; Col = 5 }, { Row = 2; Col = 6 })
  ({ Row = 3; Col = 3 }, { Row = 3; Col = 4 })
  ({ Row = 3; Col = 5 }, { Row = 3; Col = 6 })
  ({ Row = 5; Col = 4 }, { Row = 5; Col = 5 })
  ({ Row = 6; Col = 1 }, { Row = 6; Col = 2 })
  ({ Row = 6; Col = 6 }, { Row = 6; Col = 7 })
  ({ Row = 7; Col = 1 }, { Row = 7; Col = 2 })

  // Vertical walls
  ({ Row = 3; Col = 0 }, { Row = 4; Col = 0 })
  ({ Row = 5; Col = 1 }, { Row = 6; Col = 1 })
  ({ Row = 1; Col = 2 }, { Row = 2; Col = 2 })
  ({ Row = 1; Col = 3 }, { Row = 2; Col = 3 })
  ({ Row = 3; Col = 3 }, { Row = 4; Col = 3 })
  ({ Row = 3; Col = 4 }, { Row = 4; Col = 4 })
  ({ Row = 6; Col = 4 }, { Row = 7; Col = 4 })
  ({ Row = 2; Col = 5 }, { Row = 3; Col = 5 })
  ({ Row = 0; Col = 7 }, { Row = 1; Col = 7 })
]

// ------------------------------------------------------------
// Hard map
// ------------------------------------------------------------

let hardWalls : (Position * Position) list = [
  // Horizontal walls
  ({ Row = 0; Col = 3 }, { Row = 0; Col = 4 })
  ({ Row = 1; Col = 1 }, { Row = 1; Col = 2 })
  ({ Row = 2; Col = 2 }, { Row = 2; Col = 3 })
  ({ Row = 2; Col = 5 }, { Row = 2; Col = 6 })
  ({ Row = 3; Col = 4 }, { Row = 3; Col = 5 })
  ({ Row = 4; Col = 1 }, { Row = 4; Col = 2 })
  ({ Row = 5; Col = 1 }, { Row = 5; Col = 2 })
  ({ Row = 5; Col = 2 }, { Row = 5; Col = 3 })
  ({ Row = 5; Col = 4 }, { Row = 5; Col = 5 })
  ({ Row = 5; Col = 6 }, { Row = 5; Col = 7 })
  ({ Row = 6; Col = 5 }, { Row = 6; Col = 6 })
  ({ Row = 7; Col = 3 }, { Row = 7; Col = 4 })

  // Vertical walls
  ({ Row = 1; Col = 0 }, { Row = 2; Col = 0 })
  ({ Row = 3; Col = 0 }, { Row = 4; Col = 0 })
  ({ Row = 4; Col = 0 }, { Row = 5; Col = 0 })
  ({ Row = 5; Col = 1 }, { Row = 6; Col = 1 })
  ({ Row = 2; Col = 2 }, { Row = 3; Col = 2 })
  ({ Row = 5; Col = 2 }, { Row = 6; Col = 2 })
  ({ Row = 5; Col = 3 }, { Row = 6; Col = 3 })
  ({ Row = 1; Col = 4 }, { Row = 2; Col = 4 })
  ({ Row = 4; Col = 4 }, { Row = 5; Col = 4 })
  ({ Row = 0; Col = 5 }, { Row = 1; Col = 5 })
  ({ Row = 6; Col = 5 }, { Row = 7; Col = 5 })
  ({ Row = 6; Col = 6 }, { Row = 7; Col = 6 })
  ({ Row = 1; Col = 7 }, { Row = 2; Col = 7 })
  ({ Row = 4; Col = 7 }, { Row = 5; Col = 7 })
]

let easyMap = {
  Name = "Basic Slide Maze"
  Difficulty = "Easy"
  Walls = easyWalls
}

let mediumMap = {
  Name = "Twisted Slide Maze"
  Difficulty = "Medium"
  Walls = mediumWalls
}

let hardMap = {
  Name = "Tight Slide Maze"
  Difficulty = "Hard"
  Walls = hardWalls
}

let maps = [
  easyMap
  mediumMap
  hardMap
]

let createInitialState selectedMap = {
  Player = startPos
  Start = startPos
  Exit = exitPos
  Map = selectedMap
}
