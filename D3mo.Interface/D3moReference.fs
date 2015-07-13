namespace D3mo.Interface

open System

type D3moReference(id : Guid, name : string) = 
    member this.Id = id
    member this.Name = name
