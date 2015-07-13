namespace D3mo.Interface

open System.Collections.Generic

type ITimeRecordSet = 
   abstract member GetRecords : unit -> IEnumerable<TimeRecord>