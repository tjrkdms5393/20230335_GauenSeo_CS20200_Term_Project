module SlideMazeEscape.Game

open SlideMazeEscape.Types
open SlideMazeEscape.Maze

let nextPosition pos direction =
  match direction with
  | Up -> { pos with Row = pos.Row - 1 }
  | Left -> { pos with Col = pos.Col - 1 }
  | Down -> { pos with Row = pos.Row + 1 }
  | Right -> { pos with Col = pos.Col + 1 }

let canMoveFrom state pos direction =
  let next = nextPosition pos direction
  isValidPosition next && not (hasWallBetween state.Map.Walls pos next)

let rec slide state pos direction =
  if canMoveFrom state pos direction then
    let next = nextPosition pos direction

    if samePosition next state.Exit then
      next
    else
      slide state next direction
  else
    pos

let moveState state direction =
  let newPlayer = slide state state.Player direction
  { state with Player = newPlayer }

let hasWon state =
  samePosition state.Player state.Exit

let parseDirection (input: string) =
  match input.Trim().ToUpper() with
  | "W" -> Some Up
  | "A" -> Some Left
  | "S" -> Some Down
  | "D" -> Some Right
  | _ -> None

let isRestartInput (input: string) =
  input.Trim().ToUpper() = "R"

let isQuitInput (input: string) =
  input.Trim().ToUpper() = "Q"

let isMapSelectInput (input: string) =
  input.Trim().ToUpper() = "M"