namespace D3mo.Services.Default

open System
open System.Collections.Generic
open D3mo.Interface
open FSharp.Data

type TimeStacksReader = CsvProvider<"TimeStacks.csv">

type DefaultTimeRecordSet() =

    let readData =
        use timeRecords = new TimeStacksReader()

        query {
            for r in timeRecords.Rows do
            select (r.Id, r.Date, r.Hours, D3moReference(r.ProjectId, r.ProjectName), D3moReference(r.TaskId, r.TaskName))
        }
        |> Seq.map (fun (id,date,hours,projRef,taskRef) -> 2)

    member __.X = 1