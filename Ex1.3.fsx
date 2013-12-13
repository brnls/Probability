open System

let rand = new Random()

let rollDice() =
    rand.Next(1,7)

let rollPair() = 
    (rollDice(), rollDice())

let rollX x = 
    [1..x]
    |>List.map (fun x-> rollDice())
    

//Probability of a six in four rolls of a dice.
[0..1000000]
|>List.map (fun x-> rollX 4)
|>List.map (fun x-> x |>List.tryFindIndex(fun y -> y = 6))
|>List.filter (function Some x -> true | _ -> false)
|>List.length |> float
|>fun x-> x/1000000.0


let rollPairX x =
    [1..x]
    |>List.map (fun x-> rollPair())

//Probability of a pair of sixes in 24 rolls of a dice
[0..100000]
|>List.map (fun x-> rollPairX 24)
|>List.map(fun x -> x |>List.tryFindIndex(fun (a,b) -> a = 6 && b = 6))
|>List.filter(function Some x -> true | _ -> false)
|>List.length |> float
|>fun x-> x/100000.0

1.0/sqrt(28000.0)