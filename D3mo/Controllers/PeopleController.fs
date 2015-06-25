namespace D3mo.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http

type Person = { 
    First : string
    Last : string
}


/// Retrieves values.
[<RoutePrefix("api2/people")>]
type PeopleController() =
    inherit ApiController()

    let people = [|
        { First = "John"; Last = "Trujillo"}
        { First = "Sara"; Last = "Trujillo"}
        { First = "Pat"; Last = "Esquivel"}
    |]

    /// Gets all values.
    [<Route("")>]
    member x.Get() = people

    /// Gets the value with index id.
    [<Route("{id:int}")>]
    member x.Get(id) : IHttpActionResult =
        if id > people.Length - 1 then
            x.BadRequest() :> _
        else x.Ok(people.[id]) :> _