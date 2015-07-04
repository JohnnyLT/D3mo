namespace D3mo.Services

open D3mo.Interface

module Factory =

    type Source = Default

    let getEmployeeCoaches source : IEmployeeCoach =
        match source with
        | Default -> new D3mo.Services.Default.DefaultEmployeeCoaches() :> _
