namespace D3mo

open D3mo.Services.Factory
open FSharp.Configuration

module Configuration = 

    type Settings = AppSettings<"Web.config">

    let serviceType = 
        match Settings.DemoMode with
        | "Default" 
        | _         -> Source.Default

