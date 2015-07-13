namespace D3mo.Interface

open System

type TimeRecord (id : Guid, date : DateTime, hours : double, project : D3moReference, task : D3moReference) =
    member __.Id = id
    member __.Date = date
    member __.Hours = hours
    member __.Project = project
    member __.Task = task