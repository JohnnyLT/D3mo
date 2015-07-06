namespace D3mo.Services.Default

open System
open System.Collections.Generic
open D3mo.Interface

type DefaultEmployeeCoaches() =  

    let relationships =
        Helpers.getCoachData
        |> List.map 
            (fun (eId, eN, cId, cN) -> 
                EmployeeRelationship (EmployeeInfo(Guid.Parse(eId), eN), EmployeeInfo(Guid.Parse(cId), cN)))
        |> List.toArray

    interface IEmployeeCoach with
        member this.GetEmployeeCoaches() = 
            new List<EmployeeRelationship>(relationships) :> _
