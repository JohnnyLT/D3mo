namespace D3mo.Interface

open System

type TimeRecord (id : Guid, date : DateTime, hours : double, project : ForeignKey, task : ForeignKey, isBilledToProject : bool) =
    member __.Id = id
    member __.Date = date
    member __.Hours = hours
    member __.Project = project
    member __.Task = task
    member __.IsBilledToProject = isBilledToProject