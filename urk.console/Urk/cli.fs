module Urk.Cli

open System

open Argu

type LintMode =
  | Fatal   = 1
  | Invalid = 2

type UrkArg =
  | [<AltCommandLine("-f")>] File                of string
  | [<AltCommandLine("-F")>] Field_Separator     of string
  | [<AltCommandLine("-v")>] Assign              of string * string
  | [<AltCommandLine("-b")>] Characters_As_Bytes
  | [<AltCommandLine("-c")>] Traditional
  | [<AltCommandLine("-C")>] Copyright
  | [<AltCommandLine("-d")>] Dump_Variables      of string
  | [<AltCommandLine("-D")>] Debug               of string
  | [<AltCommandLine("-e")>] Source              of string
  | [<AltCommandLine("-E")>] Exec                of string
  | [<AltCommandLine("-g")>] Gen_Pot
  | [<AltCommandLine("-i")>] Include             of string
  | [<AltCommandLine("-l")>] Load                of string
  | [<AltCommandLine("-M")>] Bignum
  | [<AltCommandLine("-N")>] Use_Ic_Numeric
  | [<AltCommandLine("-n")>] Non_Decimal_Data
  | [<AltCommandLine("-o")>] Pretty_Print        of string
  | [<AltCommandLine("-O")>] Optimize
  | [<AltCommandLine("-p")>] Profile             of string
  | [<AltCommandLine("-P")>] Posix
  | [<AltCommandLine("-r")>] Re_Interval
  | [<AltCommandLine("-S")>] Sandbox
  | [<AltCommandLine("-t")>] Lint                of LintMode
  | [<AltCommandLine("-V")>] Version
  with
    interface IArgParserTemplate with
      member this.Usage =
        match this with
         | File _                 -> ""
         | Field_Separator _      -> ""
         | Assign _               -> ""
         | Characters_As_Bytes    -> ""
         | Traditional            -> ""
         | Copyright              -> ""
         | Dump_Variables _       -> ""
         | Debug _                -> ""
         | Source _               -> ""
         | Exec _                 -> ""
         | Gen_Pot                -> ""
         | Include _              -> ""
         | Load _                 -> ""
         | Bignum                 -> ""
         | Use_Ic_Numeric         -> ""
         | Non_Decimal_Data       -> ""
         | Pretty_Print _         -> ""
         | Optimize               -> ""
         | Profile _              -> ""
         | Posix                  -> ""
         | Re_Interval            -> ""
         | Sandbox                -> ""
         | Lint _                 -> ""
         | Version                -> ""

let create_parser () =
  ArgumentParser.Create<UrkArg>()

let parsed_args_or_exception (parser : ArgumentParser<UrkArg>) (args : string[]) =
  try
    let args   = args |> Seq.skip 1 |> Array.ofSeq in
    Choice1Of2( parser.Parse( args ) )
  with | ex -> Choice2Of2( ex )

let print_line (text : string) =
  Console.WriteLine( text )

let print_version () =
  print_line "urk 0.1.0"

let print_usage (parser : ArgumentParser<UrkArg>) =
  print_line ( parser.PrintUsage() )
