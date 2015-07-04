namespace D3mo.Interface

open System
open System.Collections.Generic

type EmployeeInfo(id : System.Guid, fullName : System.String) = 
    member this.Id = id
    member this.FullName = fullName

type EmployeeRelationship(employee : EmployeeInfo, coach : EmployeeInfo) =
    member this.Employee = employee
    member this.Coach = coach

type IEmployeeCoach = 
   abstract member GetEmployeeCoaches : unit -> IEnumerable<EmployeeRelationship>

type TestEmployeeCoach() =        
    let employee = EmployeeInfo(Guid.NewGuid(), "John Trujillo")
    let coach = EmployeeInfo(Guid.NewGuid(), "Blake Scarlavai")
    let relationship = new EmployeeRelationship(employee,coach)
    let relationships = [|relationship|]

    interface IEmployeeCoach with

        member this.GetEmployeeCoaches() = 
            new List<EmployeeRelationship>(relationships) :> _
