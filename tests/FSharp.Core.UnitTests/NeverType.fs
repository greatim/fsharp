namespace FSharp.Core.UnitTests


module NeverTypeTests =
  open TypeRegulate
// Usage: I set `x` must belong to option<_>��but not `int option' or `unit option'

    let inline assertType (x) = 
          x |> TypeDiffer<_ option, int option>.Id
            |> TypeDiffer<_ , unit option>.Id
            |> nnid


(**************************************
    Test 1: `FS0043`
        option<int> is disallowed         *)

    let foo(x: int option) = assertType x 


(*************************************
    Test 2: `FS0043`
        option<unit> is disallowed         *)

    let foo1(x: unit option) = assertType x



(**************************************
    Test 3: OK
        `option<string>` is allowed. *)

    let foo2(x: string option) = assertType x



(**************************************
    Test 4: OK
        `option<T>` is explicitly specified as generic, it is OK too, *)
    let foo3(x: 'T option) = assertType x



(**************************************
    Test 5: `FS0043`
        because it's not explicitly specified as generic *)

    let bindType(x: 'T option) = ()
    let foo4 x = 
        assertType x
        bindType x
