namespace D3mo.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open D3mo.Services

[<RoutePrefix("api2/EmployeeCoaches")>]
type EmployeeCoachesController() =
    inherit ApiController()

    let serviceType = D3mo.Configuration.serviceType

    let employeeCoachService = Factory.getEmployeeCoaches serviceType

    /// Gets all values.
    [<Route("")>]
    member x.Get() = employeeCoachService.GetEmployeeCoaches()

    /// Gets the value with index id.
//    [<Route("{id:int}")>]
//    member x.Get(id) : IHttpActionResult =
//        if id > 1 then
//            x.BadRequest() :> _
//        else x.Ok(employeeCoachService.GetEmployeeCoaches().First()) :> _

