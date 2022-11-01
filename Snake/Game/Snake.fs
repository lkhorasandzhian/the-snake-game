module Snake

open System

type position = { row: int; column: int }

type Snake() =
    let symbolChain = "●"
    let symbolHead = "○"

    let mutable listPoints: position list = []

    let lastIndex() = listPoints.Length - 1

    let drawHead() =
        Console.SetCursorPosition(listPoints[lastIndex()].row, listPoints[lastIndex()].column)
        Console.Write(symbolHead)

    let drawSnake() =
        for point in listPoints do
            Console.SetCursorPosition(point.row, point.column)
            Console.Write(symbolChain)

        drawHead()

    let erase() =
        Console.SetCursorPosition(listPoints[0].row, listPoints[0].column)
        Console.Write(" ")

    let moveSnake direction =
        let pointHead = listPoints.Item(lastIndex ())

        let mutable x = 0
        let mutable y = 0

        match direction with
        | 1 when pointHead.row < (Console.WindowWidth - 1) -> x <- 1
        | 2 when pointHead.row > 0 -> x <- -1
        | 3 when pointHead.column < (Console.WindowWidth - 1) -> y <- 1
        | 4 when pointHead.column > 0 -> y <- -1
        | _ -> ()

        if x <> 0 || y <> 0 then
            erase()

            let pointNew = { row = pointHead.row + x
                             column = pointHead.column + y }

            listPoints <- listPoints.Tail @ [pointNew]

            drawSnake()

    do
        for i = 0 to 25 do
            let point = { row = i
                          column = 0 }
            listPoints <- listPoints @ [ point ]

        drawSnake()

    member _.Move(currentDirection: int) = moveSnake currentDirection
    member _.HeadPoint = listPoints[lastIndex()]
