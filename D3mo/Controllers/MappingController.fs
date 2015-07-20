namespace D3mo.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

type MappingController() =
    inherit Controller()
    member this.ChoroplethUsMap () = this.View("ChoroplethUS")
    member this.GeoJson () = this.View("GeoJson")
    member this.Index () = this.View()
    member this.SimplePolygon () = this.View("SimplePolygon")
    member this.UsMap () = this.View("US")