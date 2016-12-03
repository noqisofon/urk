module Urk.Console

open Urk.Cli

[<EntryPoint>]
let main argv =
  let parser = create_parser ()
  try
    let result = parser.Parse argv

    let is_version = result.Contains <@ Version @>

    match is_version with
      | true     -> print_version()
      | false    -> print_line "Hello, World!"
    0

  with
    | exn ->
      print_usage parser
      0

