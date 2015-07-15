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
            select (r.Id, r.Date, (double)r.Hours, D3moReference(r.ProjectId, r.ProjectName), D3moReference(r.TaskId, r.TaskName)) }
        |> Seq.map (fun (id,date,hours,projRef,taskRef) -> new TimeRecord(id,date,hours, projRef, taskRef))
        |> Seq.toList

    interface ITimeRecordSet with
        member __.GetRecords() = 
            new List<TimeRecord>(readData) :> _