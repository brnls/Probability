
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

let CombinedOutcomes resultSet =
    ["Heads", getResultsOf Heads resultSet
     "Tails", getResultsOf Tails resultSet
     ] 

let ResultSet = (DoFlips 100)

Chart.WithYAxis(Max=100.0)
Chart.Column (CombinedOutcomes ResultSet)


    
