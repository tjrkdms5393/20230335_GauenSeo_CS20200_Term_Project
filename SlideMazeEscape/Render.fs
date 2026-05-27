module SlideMazeEscape.Render

open System
open SlideMazeEscape.Types
open SlideMazeEscape.Maze

let cellChar (state: GameState) row col =
  let pos: Position = { Row = row; Col = col }

  if samePosition state.Player pos then
    "P"
  else
    " "

let outsideChar (state: GameState) row col =
  let pos: Position = { Row = row; Col = col }

  if samePosition state.Player pos then
    "P"
  elif samePosition state.Exit pos then
    "E"
  else
    " "

let printOutsideRow (state: GameState) row =
  printf " "

  for col in 0 .. size - 1 do
    printf " %s  " (outsideChar state row col)

  printfn ""

let printBoundaryWithOpening openingCol =
  for col in 0 .. size - 1 do
    printf "+"

    if col = openingCol then
      printf "   "
    else
      printf "---"

  printfn "+"

let printTopBoundary () =
  for _ in 0 .. size - 1 do
    printf "+---"
  printfn "+"

let printCellRow (state: GameState) row =
  for col in 0 .. size - 1 do
    let current: Position = { Row = row; Col = col }

    if col = 0 then
      printf "|"

    printf " %s " (cellChar state row col)

    if col = size - 1 then
      printf "|"
    else
      let right: Position = { Row = row; Col = col + 1 }

      if hasWallBetween state.Map.Walls current right then
        printf "|"
      else
        printf " "

  printfn ""

let printHorizontalWalls (state: GameState) row =
  for col in 0 .. size - 1 do
    let current: Position = { Row = row; Col = col }
    let below: Position = { Row = row + 1; Col = col }

    printf "+"

    if hasWallBetween state.Map.Walls current below then
      printf "---"
    else
      printf "   "

  printfn "+"

let printMaze (state: GameState) =
  Console.Clear()

  printfn "Slide Maze Escape"
  printfn "Map: %s (%s)" state.Map.Name state.Map.Difficulty
  printfn "Controls: W/A/S/D = move, R = restart, M = map select, Q = quit"
  printfn ""

  printOutsideRow state -1

  printBoundaryWithOpening state.Exit.Col

  for row in 0 .. size - 1 do
    printCellRow state row

    if row = size - 1 then
      printBoundaryWithOpening state.Start.Col
    else
      printHorizontalWalls state row

  printOutsideRow state size

  printfn ""