module Urk.Parser

open FParsec

let ws = spaces
let str s = pstring s

