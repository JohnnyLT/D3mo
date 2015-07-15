// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open D3mo.Services

[<EntryPoint>]
let main argv = 

    let set = Factory.getTimeRecordSet Factory.Default

    let x = 
        set.GetRecords()
        |> Seq.iter (fun tr -> printfn "%A" tr.Date)

    let y =        
       query {
           for tr in set.GetRecords() do
           groupBy (tr.Date, tr.Project.Id, tr.Project.Name) into g
           select g
       }
       |> Seq.map (fun gr -> (gr.Key, gr |> Seq.toList |> Seq.map (fun i -> i.Hours) |> Seq.sum))

    let z = y

    0 // return an integer exit code
