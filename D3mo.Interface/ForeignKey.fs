namespace D3mo.Interface

open System

type ForeignKey(id : Guid, name : string) = 
    member this.Id = id
    member this.Name = name
