module SlideMazeEscape.Program

open System
open SlideMazeEscape.Maze
open SlideMazeEscape.Game
open SlideMazeEscape.Render

let rec selectMap () =
  Console.Clear()

  printfn "Slide Maze Escape"
  printfn ""
  printfn "Select a map:"
  printfn ""

  maps
  |> List.iteri (fun index mazeMap ->
    printfn "%d. %s (%s)" (index + 1) mazeMap.Name mazeMap.Difficulty)

  printfn ""
  printfn "Q. Quit"
  printfn ""
  printf "Enter 1, 2, 3, or Q: "

  let input = Console.ReadLine()

  if isNull input then
    None
  else
    match input.Trim().ToUpper() with
    | "1" -> Some maps.[0]
    | "2" -> Some maps.[1]
    | "3" -> Some maps.[2]
    | "Q" -> None
    | _ ->
        printfn ""
        printfn "Invalid input. Please enter 1, 2, 3, or Q."
        printfn "Press Enter to continue."
        Console.ReadLine() |> ignore
        selectMap ()

and startGame () =
  match selectMap () with
  | Some selectedMap ->
      let initialState = createInitialState selectedMap
      gameLoop initialState
  | None ->
      printfn "Game closed."
      0

and gameLoop state =
  printMaze state

  if hasWon state then
    printfn "You reached the exit. You win!"
    System.Threading.Thread.Sleep(1500)
    startGame ()
  else
    printf "Enter command: "
    let input = Console.ReadLine()

    if isNull input then
      printfn "Input ended. Game closed."
      0

    elif isQuitInput input then
      printfn "Game closed."
      0

    elif isMapSelectInput input then
      startGame ()

    elif isRestartInput input then
      let restartedState = createInitialState state.Map
      gameLoop restartedState

    else
      match parseDirection input with
      | Some direction ->
          let newState = moveState state direction
          gameLoop newState

      | None ->
          printfn "Invalid input. Please enter W, A, S, D, R, M, or Q."
          printfn "Press Enter to continue."
          Console.ReadLine() |> ignore
          gameLoop state

[<EntryPoint>]
let main _ =
  startGame ()