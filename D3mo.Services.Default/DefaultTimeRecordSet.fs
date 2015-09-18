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
            select (
                r.Id, 
                r.Date, 
                (double)r.Hours, 
                ForeignKey(r.ProjectId, r.ProjectName), 
                ForeignKey(r.TaskId, r.TaskName), 
                r.IsBillable
            )
        }
        |> Seq.map (
            fun (id,date,hours,projRef,taskRef, isBillable) 
                -> new TimeRecord(id,date,hours, projRef, taskRef, isBillable)
            )
        |> Seq.toList

    interface ITimeRecordSet with
        member __.GetRecords() = 
            new List<TimeRecord>(readData) :> _