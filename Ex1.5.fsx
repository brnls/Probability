
#load @"C:/Users/brians/Documents/Visual Studio 2012/Projects/ConsoleApplication5/packages/FSharp.Charting.0.90.5\FSharp.Charting.fsx"

open FSharp.Charting
open System


let rand = new Random()

type Outcome = 
    |Acorn
    |Balky
    |Chestnut
    |Dolby

let race() =
    match rand.NextDouble() with
    |x when x <= 0.30 -> Acorn
    |x when x <= 0.70 -> Balky
    |x when x <= 0.90 -> Chestnut
    |x when x <= 1.00 -> Dolby
    |_ -> failwith "error"

let getResultsOf resultType resultSet = 
    resultSet
    |> List.filter (fun x -> x = resultType)
    |> List.length

let CombinedOutcomes resultSet =
    ["Acorn", getResultsOf Acorn resultSet
     "Balky", getResultsOf Balky resultSet
     "Chestnut", getResultsOf Chestnut resultSet
     "Dolby", getResultsOf Dolby resultSet
     ] 

let raceX x= 
    [0..x]
    |>List.map(fun x-> race())
    |>CombinedOutcomes

let myChart = Chart.Column (raceX 10000)