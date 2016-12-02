module Urk.Ast

// type Numeric =
//   | Integer of int
//   | 

type Atom =
  | UString of string
  | UNumber of float
  | UBool   of bool
  | UNull
  | UList   of Atom list
  | UObject of Map<string, Atom>
