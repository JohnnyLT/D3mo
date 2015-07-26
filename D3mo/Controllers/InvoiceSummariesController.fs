namespace D3mo.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open D3mo.Services

/// Retrieves values.
[<RoutePrefix("api2/InvoiceSummaries")>]
type InvoiceSummariesController() =
    inherit ApiController()
    
    let invoiceService = 
        Factory.getInvoiceSummaryService D3mo.Configuration.serviceType

    /// Gets all values.
    [<Route("")>]
    member x.Get() = invoiceService.GetActiveInvoiceSummaries()