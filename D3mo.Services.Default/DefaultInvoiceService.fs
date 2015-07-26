namespace D3mo.Services.Default

open System
open System.Collections.Generic
open D3mo.Interface
open FSharp.Data

type InvoiceSummariesReader = CsvProvider<"Invoices.csv">

type DefaultInvoiceService() =    

    let readData =
        use invoiceRecords = new InvoiceSummariesReader()

        query {
            for r in invoiceRecords.Rows do
            let location = new Invoice.Location(r.City, r.State, r.Country, double r.Latitude, double r.Longitude)
            let invoice = new Invoice.Invoice(r.TotalInvoices, r.LastYearInvoices)
            select (new Invoice.Summary(r.Id, r.Name, location, invoice))
        }
        |> Seq.toList

    interface IInvoiceService with
        member __.GetActiveInvoiceSummaries() = 
            new List<Invoice.Summary>(readData) :> _