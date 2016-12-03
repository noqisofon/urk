module Urk.Console.Tests

open Argu
open NUnit.Framework

open Urk.CliStub


[<TestFixture>]
type CliTest() = class

  [<Test>]
  member self.Test01() =
    let parser = create_parser()

    //Assert.Throws<ArguParseException>( fun _ -> ignore ( parser.Parse( [| "--help" |] ) ) )
    let results = parser.Parse( [| "--help" |] )

    Assert.IsTrue( results.IsUsageRequested )
end
