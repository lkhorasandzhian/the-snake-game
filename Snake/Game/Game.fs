module Game

open System
open System.Timers

type Game() =
    let timer = new Timer(Interval = 125, Enabled = true)

    let snake = Snake.Snake()

    let mutable direction = 0

    let gameStop(pos: Snake.position) =
        if pos.row = 0 && pos.column = 0 then
            direction <- 1

        if pos.row = Console.WindowWidth - 1 && pos.column = 0 then
            direction <- 3

        if pos.row = Console.WindowWidth - 1 && pos.column = Console.WindowWidth - 1 then
            direction <- 2

        if pos.row = 0 && pos.column = Console.WindowWidth - 1 then
            direction <- 4

    let timerClick (_source: Object) (_eventArg: System.Timers.ElapsedEventArgs) : unit =
        snake.Move direction
        gameStop(snake.HeadPoint)

        Console.CursorVisible <- false

    do timer.Elapsed.AddHandler(timerClick)

    member _.Right() = direction <- 1
    member _.Left() = direction <- 2
    member _.Down() = direction <- 3
    member _.Up() = direction <- 4
