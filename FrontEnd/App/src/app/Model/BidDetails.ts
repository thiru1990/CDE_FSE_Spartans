export class BidDetails{
    shortDescription: string
    detailedDescription :string
    category:string //should be enum
    startingPrice :number
    bidEndDate :Date
    bidsReceived :BidsReceived[]
}

export class BidsReceived{
      email:string
      bidAmount :number
}