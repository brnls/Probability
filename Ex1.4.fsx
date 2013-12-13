
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


let myScan transformer initState list =
    let rec loop s xs acc =
        match xs with
        | [] -> List.rev acc
        |(h::t) -> let res = transformer s h in loop res t (res :: acc)
    loop initState list [initState]



List.scan (fun x y -> x + y) 0 [1..5]

let play() = 
    [0..40]
    |>List.map(fun x -> 
        match flip() with
        |Heads -> 1
        |Tails -> -1)
    |> List.scan (fun x y -> x + y) 0
    |> List.rev |>List.head


[0..1000]
|>List.map (fun x-> float (play()))
|>List.average
