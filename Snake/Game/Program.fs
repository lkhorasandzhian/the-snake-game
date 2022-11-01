open System

Console.BackgroundColor <- ConsoleColor.DarkGreen
Console.ForegroundColor <- ConsoleColor.DarkMagenta
Console.OutputEncoding <- System.Text.Encoding.UTF8

Console.Clear()
Console.Title <- @"""The Snake"" Game"

let game = Game.Game()

[<EntryPoint>]
let main _ =
    let mutable control = ConsoleKey.A

    while control <> ConsoleKey.Spacebar do
        let signal = Console.ReadKey(true)

        if signal.Key = ConsoleKey.RightArrow then
            game.Right()

        else if signal.Key = ConsoleKey.LeftArrow then
            game.Left()

        else if signal.Key = ConsoleKey.DownArrow then
            game.Down()
            
        else if signal.Key = ConsoleKey.UpArrow then
            game.Up()
        
        control <- signal.Key

    0
