module Urk.Console

open Urk.Cli

[<EntryPoint>]
let main argv =
  let results = parsed_args_or_exception argv
  0
