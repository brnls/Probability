
#load @"C:/Users/brians/Documents/Visual Studio 2012/Projects/ConsoleApplication5/packages/FSharp.Charting.0.90.5\FSharp.Charting.fsx"

open FSharp.Charting
open System

let rand = new Random()
rand.Next(1,6)

type Outcome =
    |Heads
    |Tails

let flip() : Outcome =
    match rand.Next(0,2) with
    |0 -> Heads
    |1 -> Tails
    |_ -> failwith "error"

let getResultsOf resultType resultSet = 
    resultSet
    |> List.filter (fun x -> x = resultType)
    |> List.length

let DoFlips x = 
    [1..x]
    |>List.map (fun x-> flip())


//Number 2
let test x : bool= 
    DoFlips x
    |>getResultsOf Heads |> float
    |> (fun y-> y / float x)
    |> (fun y -> 0.4 <= y && y <= 0.6)

[0..100] |> List.map(fun x-> test 100) |>List.filter (fun x-> not x)

1.0/sqrt(100.0)


//3

let rollDice() =
    rand.Next(1,7)

let rollX x = 
    [1..x] |>List.map (fun x-> rollDice())

let doNTimes n = let s = [0..n] |> List.map (fun x -> (rollX 3) |>List.sum) in ("9",(float (getResultsOf 9 s))/(float n)), ("10",(float(getResultsOf 10 s))/(float n))

doNTimes 1000000

1.0 / sqrt(1000000.0)


//4

type GameOutcome =
    |Win 
    |Loss

let playGame serving =
    if serving then
        match rand.NextDouble() with
        |x when x <= 0.6 -> Win
        |_ -> Loss
    else
        match rand.NextDouble() with
        |x when x <= 0.5 -> Win
        |_ -> Loss


Seq.unfold(fun (score,serving) -> 
    let gameOutcome = playGame serving 
    match gameOutcome with 
    |Win -> if serving then Some(score + 1, ((score + 1), true)) else Some((score + 1),(score + 1, true))
    |Loss -> Some(score, (score,false))) (0, true)
|>Seq.takeWhile(fun x-> x < 21)
|> Seq.length