namespace D3mo.Interface

open System.Collections.Generic

type IInvoiceService = 
   abstract member GetActiveInvoiceSummaries : unit -> IEnumerable<Invoice.Summary>