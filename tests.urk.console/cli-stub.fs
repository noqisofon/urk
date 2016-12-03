module Urk.CliStub

open Argu

type UrkStubArg =
  | [<AltCommandLine("-f")>] File                of string
  | [<AltCommandLine("-V")>] Version
  with
    interface IArgParserTemplate with
      member this.Usage =
        match this with
         | File _                 -> ""
         | Version                -> ""

let create_parser () =
  ArgumentParser.Create<UrkStubArg>()