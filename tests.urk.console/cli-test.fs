module Urk.Console.Tests

open Argu
open NUnit.Framework

open Urk.CliStub

[<Test>]
let an_exception_sent_out_when_hand_help () =
  let parser = create_parser()

  try
    let results = parser.Parse( [| "--help" |] )

    Assert.IsTrue( results.IsUsageRequested )

  with
    | :? Argu.ArguParseException as parse_error ->
      TestContext.Out.WriteLine("error code: {0}", parse_error.ErrorCode)

      Assert.AreEqual(ErrorCode.HelpText, parse_error.ErrorCode)

      TestContext.Out.WriteLine()
      TestContext.Out.WriteLine(parse_error.Message)

      Assert.Pass()

[<Test>]
let an_exception_sent_out_when_hand_help_and_version () =
  let parser = create_parser()

  try
    let results = parser.Parse( [| "--help"; "--version" |] )

    Assert.IsTrue( results.IsUsageRequested )

  with
    | :? Argu.ArguParseException as parse_error ->
      TestContext.Out.WriteLine("error code: {0}", parse_error.ErrorCode)

      Assert.AreEqual(ErrorCode.HelpText, parse_error.ErrorCode)

      TestContext.Out.WriteLine()
      TestContext.Out.WriteLine(parse_error.Message)

      Assert.Pass()

[<Test>]
let exception_not_sent_out_when_hand_only_version () =
  let parser = create_parser()

  try
    let results = parser.Parse( [| "--version" |] )

    Assert.IsTrue( results.Contains( <@ Version @> ) )

  with
    | :? Argu.ArguParseException ->
      Assert.Fail()
  
[<Test>]
let exception_is_not_sent_out_even_if_hand_file () =
  let parser = create_parser()

  try
    let results = parser.Parse( [| "--file"; "./hoge.urk" |] )

    TestContext.Out.WriteLine()
    Assert.IsTrue( results.Contains( <@ File @> ) )

    let filename = results.GetResult( <@ File @> )
    TestContext.Out.WriteLine( "file name: {0}", filename )
    Assert.AreEqual( "./hoge.urk", filename )

  with
    | :? Argu.ArguParseException ->
      Assert.Fail()
  
