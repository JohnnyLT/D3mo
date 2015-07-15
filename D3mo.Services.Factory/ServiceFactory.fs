namespace D3mo.Services

open D3mo.Interface

module Factory =

    type Source = Default

    let getEmployeeCoachesService source : IEmployeeCoach =
        match source with
        | Default -> new D3mo.Services.Default.DefaultEmployeeCoaches() :> _

    let getTimeRecordSet source : ITimeRecordSet =
        match source with
        | Default -> new D3mo.Services.Default.DefaultTimeRecordSet() :> _
