#load "library.fsx"
open myLibrary

let Run(input: string, log: TraceWriter) =
    log.Info(
      sprintf "F# manually triggered function called with input: %s" input)
  
    let parsedArgs = input.Split [|','|] |> Seq.map int32

    let num1 = Seq.item 0 parsedArgs
    let num2 = Seq.item 1 parsedArgs

    let sum = myAdd num1 num2

    log.Info(sprintf "The sum of %d and %d is %d" num1 num2 sum)
