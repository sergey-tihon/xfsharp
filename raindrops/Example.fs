module Raindrops

type Raindrops(number: int) =
    let isPling = 
        number % 3 = 0

    let isPlang = 
        number % 5 = 0

    let isPlong =
        number % 7 = 0

    let isPlingPlanOrPlong =
        let s = System.Text.StringBuilder()

        match isPling || isPlang || isPlong with
            | true -> s.Append(number)
            | false -> (match isPling with
                            | true -> s.Append("Pling")
                            | false -> ()) 

    member this.convert() =
        