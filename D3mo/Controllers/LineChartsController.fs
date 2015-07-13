namespace D3mo.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

type LineChartsController() =
    inherit Controller()
    member this.Index () = this.View()

